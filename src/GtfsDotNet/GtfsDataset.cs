using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace GtfsDotNet
{
    public class GtfsDataset
    {
        private readonly Dictionary<GtfsFileType, ZipArchiveEntry> _entries;

        // Required files according to GTFS specification
        public static readonly GtfsFileType[] RequiredFiles = new[]
        {
            GtfsFileType.Agency,
            GtfsFileType.Stops,
            GtfsFileType.Routes,
            GtfsFileType.Trips,
            GtfsFileType.StopTimes,
            GtfsFileType.Calendar,
            GtfsFileType.CalendarDates
        };

        public GtfsDataset(Stream zipStream)
        {
            var archive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen: true);
            _entries = new Dictionary<GtfsFileType, ZipArchiveEntry>();

            foreach (var entry in archive.Entries)
            {
                var fileType = MapFileNameToType(entry.Name);
                if (fileType.HasValue)
                    _entries[fileType.Value] = entry;
            }
        }

        /// <summary>
        /// Check if a specific GTFS file exists in the feed
        /// </summary>
        public bool HasFile(GtfsFileType fileType)
        {
            return _entries.ContainsKey(fileType);
        }

        /// <summary>
        /// Check if all required GTFS files are present
        /// </summary>
        public bool HasAllRequiredFiles()
        {
            return RequiredFiles.All(HasFile);
        }

        /// <summary>
        /// Reads a GTFS file into the corresponding type
        /// </summary>
        public async Task ReadFileAsync<TData>(GtfsFileType fileType, Func<IEnumerable<TData>, Task> processBatchFunc, int batchSize = 1024)
            where TData : GtfsDataItem, new()
        {
            if (!_entries.TryGetValue(fileType, out var entry))
                throw new FileNotFoundException($"GTFS file '{fileType}' not found in feed.");

            using var stream = entry.Open();
            var reader = new GtfsDataReader<TData>();
            await reader.ReadDataAsync(stream, processBatchFunc, batchSize);
        }

        internal async Task<string[]> ReadHeadersAsync<TData>(GtfsFileType fileType)
            where TData : GtfsDataItem, new()
        {
            if (!_entries.TryGetValue(fileType, out var entry))
                throw new FileNotFoundException($"GTFS file '{fileType}' not found in feed.");

            using var stream = entry.Open();
            var reader = new GtfsDataReader<TData>();
            return await reader.ReadHeadersAsync(stream);
        }

        /// <summary>
        /// Maps a file name in the zip archive to a GtfsFileType enum
        /// </summary>
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
