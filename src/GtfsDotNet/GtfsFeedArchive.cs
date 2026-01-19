using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace GtfsDotNet
{
    public class GtfsFeedArchive
    {
        private readonly Dictionary<GtfsFileType, ZipArchiveEntry> _entries;

        private readonly List<GtfsDataItem> cachedIdDataItems = new List<GtfsDataItem>();

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

        public GtfsFeedArchive(Stream zipStream)
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

        public Dictionary<GtfsFileType, List<GtfsDataItem>> FeedData { get; }
            = new Dictionary<GtfsFileType, List<GtfsDataItem>>();

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
            await reader.ReadDataAsync(this, stream, processBatchFunc, batchSize);
        }

        public async Task<IEnumerable<TData>> ReadFullFileAsync<TData>(GtfsFileType fileType)
            where TData : GtfsDataItem, new()
        {
            if (!_entries.TryGetValue(fileType, out var entry))
                throw new FileNotFoundException($"GTFS file '{fileType}' not found in feed.");

            using var stream = entry.Open();
            var reader = new GtfsDataReader<TData>();
            List<TData> items = new List<TData>();

            await reader.ReadDataAsync(this, stream, data => { items.AddRange(data); return Task.CompletedTask; });

            return items;
        }

        public async Task<GtfsDataset> ReadDataset()
        {
            GtfsDataset dataset = new GtfsDataset();
            await dataset.ReadDataset(this);
            return dataset;
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
        internal static GtfsFileType? MapFileNameToType(string fileName)
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

        internal static string MapTypeToFileName(GtfsFileType fileType)
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
                _ => throw new ArgumentOutOfRangeException(nameof(fileType), fileType, "Unknown GTFS file type.")
            };
        }
    }
}
