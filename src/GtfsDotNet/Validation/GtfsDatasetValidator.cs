using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtfsDotNet.Validation
{
    using global::GtfsDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Reflection;

    namespace GtfsDotNet
    {
        public class GtfsDatasetValidator
        {
            private readonly ZipArchive _archive;

            public GtfsDatasetValidator(Stream zipStream)
            {
                _archive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen: true);
            }

            /// <summary>Performs full dataset validation.</summary>
            public GtfsValidationResult Validate()
            {
                var result = new GtfsValidationResult();

                // 1. Check required files
                foreach (var required in GtfsFeedArchive.RequiredFiles)
                {
                    if (!_archive.Entries.Any(e => MapFileTypeToFileName(required).Equals(e.Name, StringComparison.Ordinal)))
                        result.MissingRequiredFiles.Add(required);
                }

                // 2. Validate present files
                foreach (var entry in _archive.Entries)
                {
                    var fileType = MapFileNameToType(entry.Name);
                    if (fileType == null)
                        continue;

                    var fileValidation = ValidateFile(entry, fileType.Value);
                    if (!fileValidation.IsValid)
                        result.FileErrors.Add(fileValidation);
                }

                return result;
            }

            private GtfsFileValidationResult ValidateFile(ZipArchiveEntry entry, GtfsFileType fileType)
            {
                var fileResult = new GtfsFileValidationResult { FileType = fileType };

                // Determine expected columns via model reflection
                Type? dataType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.GetCustomAttributes<GtfsFileAttribute>()
                        .Any(attr => attr.Filename == entry.Name));

                if (dataType == null)
                {
                    fileResult.RowErrors.Add("No model class found for this file.");
                    return fileResult;
                }

                var expectedColumns = dataType.GetProperties()
                    .Select(p => p.GetCustomAttribute<GtfsPropertyAttribute>())
                    .Where(attr => attr != null)
                    .Select(attr => attr!.PropertyName)
                    .ToList();

                // Read header line
                string[] headers;
                using (var reader = new StreamReader(entry.Open()))
                {
                    if (reader.EndOfStream)
                    {
                        fileResult.RowErrors.Add("File is empty.");
                        return fileResult;
                    }

                    headers = reader.ReadLine()!.Split(',').Select(h => h.Trim()).ToArray();

                    // Check for missing columns
                    foreach (var expected in expectedColumns)
                    {
                        if (!headers.Contains(expected))
                            fileResult.MissingColumns.Add(expected);
                    }
                }

                return fileResult;
            }

            private static string MapFileTypeToFileName(GtfsFileType fileType)
            {
                return fileType switch
                {
                    GtfsFileType.Agency => "agency.txt",
                    GtfsFileType.Stops => "stops.txt",
                    GtfsFileType.Routes => "routes.txt",
                    GtfsFileType.Trips => "trips.txt",
                    GtfsFileType.StopTimes => "stop_times.txt",
                    GtfsFileType.Calendar => "calendar.txt",
                    GtfsFileType.CalendarDates => "calendar_dates.txt",
                    GtfsFileType.Frequencies => "frequencies.txt",
                    GtfsFileType.Transfers => "transfers.txt",
                    GtfsFileType.Shapes => "shapes.txt",
                    GtfsFileType.Levels => "levels.txt",
                    GtfsFileType.FeedInfo => "feed_info.txt",
                    GtfsFileType.Pathways => "pathways.txt",
                    GtfsFileType.BookingRules => "booking_rules.txt",
                    GtfsFileType.FareAttributes => "fare_attributes.txt",
                    GtfsFileType.FareRules => "fare_rules.txt",
                    GtfsFileType.FareProducts => "fare_products.txt",
                    GtfsFileType.FareMedia => "fare_media.txt",
                    GtfsFileType.FareLegRules => "fare_leg_rules.txt",
                    GtfsFileType.FareLegJoinRules => "fare_leg_join_rules.txt",
                    GtfsFileType.FareTransferRules => "fare_transfer_rules.txt",
                    GtfsFileType.Areas => "areas.txt",
                    GtfsFileType.StopAreas => "stop_areas.txt",
                    GtfsFileType.Networks => "networks.txt",
                    GtfsFileType.RouteNetworks => "route_networks.txt",
                    GtfsFileType.LocationGroups => "location_groups.txt",
                    GtfsFileType.LocationGroupStops => "location_group_stops.txt",
                    GtfsFileType.LocationsGeoJson => "locations.geojson",
                    GtfsFileType.Translations => "translations.txt",
                    _ => throw new ArgumentOutOfRangeException(nameof(fileType))
                };
            }

            private static GtfsFileType? MapFileNameToType(string fileName)
            {
                return fileName switch
                {
                    "agency.txt" => GtfsFileType.Agency,
                    "stops.txt" => GtfsFileType.Stops,
                    "routes.txt" => GtfsFileType.Routes,
                    "trips.txt" => GtfsFileType.Trips,
                    "stop_times.txt" => GtfsFileType.StopTimes,
                    "calendar.txt" => GtfsFileType.Calendar,
                    "calendar_dates.txt" => GtfsFileType.CalendarDates,
                    "frequencies.txt" => GtfsFileType.Frequencies,
                    "transfers.txt" => GtfsFileType.Transfers,
                    "shapes.txt" => GtfsFileType.Shapes,
                    "levels.txt" => GtfsFileType.Levels,
                    "feed_info.txt" => GtfsFileType.FeedInfo,
                    "pathways.txt" => GtfsFileType.Pathways,
                    "booking_rules.txt" => GtfsFileType.BookingRules,
                    "fare_attributes.txt" => GtfsFileType.FareAttributes,
                    "fare_rules.txt" => GtfsFileType.FareRules,
                    "fare_products.txt" => GtfsFileType.FareProducts,
                    "fare_media.txt" => GtfsFileType.FareMedia,
                    "fare_leg_rules.txt" => GtfsFileType.FareLegRules,
                    "fare_leg_join_rules.txt" => GtfsFileType.FareLegJoinRules,
                    "fare_transfer_rules.txt" => GtfsFileType.FareTransferRules,
                    "areas.txt" => GtfsFileType.Areas,
                    "stop_areas.txt" => GtfsFileType.StopAreas,
                    "networks.txt" => GtfsFileType.Networks,
                    "route_networks.txt" => GtfsFileType.RouteNetworks,
                    "location_groups.txt" => GtfsFileType.LocationGroups,
                    "location_group_stops.txt" => GtfsFileType.LocationGroupStops,
                    "locations.geojson" => GtfsFileType.LocationsGeoJson,
                    "translations.txt" => GtfsFileType.Translations,
                    _ => null
                };
            }
        }
    }

}
