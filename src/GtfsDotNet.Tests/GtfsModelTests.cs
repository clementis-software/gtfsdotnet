using GtfsDotNet.Attributes;
using System.Reflection;

namespace GtfsDotNet.Tests
{
    public class GtfsModelTests
    {
        // List of GTFS dataset files and expected property names (according to specification)
        private static readonly Dictionary<string, string[]> ExpectedFilesAndProperties = new()
    {
        { "agency.txt", new[] { "agency_id", "agency_name", "agency_url", "agency_timezone", "agency_lang", "agency_phone", "agency_fare_url", "agency_email" } },
        { "stops.txt", new[] { "stop_id", "stop_code", "stop_name", "stop_desc", "stop_lat", "stop_lon", "zone_id", "stop_url", "location_type", "parent_station", "stop_timezone", "wheelchair_boarding" } },
        { "routes.txt", new[] { "route_id", "agency_id", "route_short_name", "route_long_name", "route_desc", "route_type", "route_url", "route_color", "route_text_color" } },
        { "trips.txt", new[] { "route_id", "service_id", "trip_id", "trip_headsign", "trip_short_name", "direction_id", "block_id", "shape_id", "wheelchair_accessible", "bikes_allowed" } },
        { "stop_times.txt", new[] { "trip_id", "arrival_time", "departure_time", "stop_id", "stop_sequence", "stop_headsign", "pickup_type", "drop_off_type", "shape_dist_traveled", "timepoint" } },
        { "calendar.txt", new[] { "service_id", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday", "start_date", "end_date" } },
        { "calendar_dates.txt", new[] { "service_id", "date", "exception_type" } },
        { "frequencies.txt", new[] { "trip_id", "start_time", "end_time", "headway_secs", "exact_times" } },
        { "transfers.txt", new[] { "from_stop_id", "to_stop_id", "transfer_type", "min_transfer_time" } },
        { "shapes.txt", new[] { "shape_id", "shape_pt_lat", "shape_pt_lon", "shape_pt_sequence", "shape_dist_traveled" } },
        { "levels.txt", new[] { "level_id", "level_index", "level_name" } },
        { "feed_info.txt", new[] { "feed_publisher_name", "feed_publisher_url", "feed_lang", "feed_start_date", "feed_end_date", "feed_version" } },
        { "pathways.txt", new[] { "pathway_id", "from_stop_id", "to_stop_id", "pathway_mode", "is_bidirectional", "length", "traversal_time", "stair_count", "max_slope", "min_width", "signposted_as", "reversed_signposted_as" } },
        { "booking_rules.txt", new[] { "booking_rule_id", "from_stop_id", "to_stop_id", "from_area_id", "to_area_id", "from_location_id", "to_location_id", "booking_contact_id", "booking_time", "max_booking_time", "min_booking_time", "requires_booking" } },
        // Add other optional GTFS files if needed
    };

        [Fact]
        public void AllGtfsClassesAndProperties_ShouldBePresent()
        {
            var assembly = Assembly.GetAssembly(typeof(GtfsDataItem));
            Assert.NotNull(assembly);

            foreach (var kvp in ExpectedFilesAndProperties)
            {
                string fileName = kvp.Key;
                string[] expectedProps = kvp.Value;

                // Find class with [GtfsFile("fileName")]
                var gtfsType = assembly.GetTypes()
                    .FirstOrDefault(t => t.GetCustomAttributes<GtfsFileAttribute>()
                        .Any(attr => attr.Filename == fileName));

                Assert.NotNull(gtfsType); // Class must exist for this file

                // Check that all expected properties exist
                var classProps = gtfsType.GetProperties()
                    .Select(p => p.GetCustomAttribute<GtfsPropertyAttribute>())
                    .Where(attr => attr != null)
                    .Select(attr => attr.PropertyName)
                    .ToArray();

                foreach (var expectedProp in expectedProps)
                {
                    Assert.Contains(expectedProp, classProps);
                }
            }
        }
    }
}
