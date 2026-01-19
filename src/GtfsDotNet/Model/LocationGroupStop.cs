using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Associates specific stops with a location group for fare calculation purposes.
    /// Part of the GTFS Fares V2 extension.
    /// </summary>
    [GtfsFile("location_group_stops.txt")]
    public class LocationGroupStop : GtfsDataItem
    {
        /// <summary>
        /// Identifies the location group. References <see cref="LocationGroup.LocationGroupId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("location_group_id", 0)]
        [GtfsReference<LocationGroup>]
        public string LocationGroupId { get; set; }

        /// <summary>
        /// Identifies a stop or station that belongs to the location group.
        /// References stop_id in stops.txt.
        /// (Required)
        /// </summary>
        [GtfsProperty("stop_id", 1)]
        [GtfsReference<Stop>]
        public string StopId { get; set; }
    }
}