using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents an individual stop, station, entrance/exit, or generic node.
    /// Corresponds to the stops.txt file.
    /// </summary>
    [GtfsFile("stops.txt")]
    public class Stop : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies a stop, station, or station entrance.
        /// (Required)
        /// </summary>
        [GtfsProperty("stop_id", 0)]
        [GtfsId]
        public string StopId { get; set; }

        /// <summary>
        /// Short text or a number that identifies the stop for riders (e.g., a pole number).
        /// (Optional)
        /// </summary>
        [GtfsProperty("stop_code", 1)]
        public string StopCode { get; set; }

        /// <summary>
        /// Name of the location (e.g., "Hauptbahnhof" or "7th Ave at 33rd St").
        /// (Required when LocationType is 0, 1, or 2)
        /// </summary>
        [GtfsProperty("stop_name", 2)]
        public string StopName { get; set; }

        /// <summary>
        /// Description of the location that provides useful, additional information.
        /// (Optional)
        /// </summary>
        [GtfsProperty("stop_desc", 3)]
        public string StopDescription { get; set; }

        /// <summary>
        /// Latitude of the location in WGS84 coordinates.
        /// (Required for LocationType 0, 1, and 2)
        /// </summary>
        [GtfsProperty("stop_lat", 4)]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the location in WGS84 coordinates.
        /// (Required for LocationType 0, 1, and 2)
        /// </summary>
        [GtfsProperty("stop_lon", 5)]
        public double Longitude { get; set; }

        /// <summary>
        /// Defines the fare zone for this stop. Used in Fares V1.
        /// (Optional)
        /// </summary>
        [GtfsProperty("zone_id", 6)]
        public string ZoneId { get; set; }

        /// <summary>
        /// URL of a web page about the location.
        /// (Optional)
        /// </summary>
        [GtfsProperty("stop_url", 7)]
        public string StopUrl { get; set; }

        /// <summary>
        /// Type of the location (Stop, Station, Entrance, etc.).
        /// References the <see cref="LocationType"/> enum.
        /// (Optional)
        /// </summary>
        [GtfsProperty("location_type", 8)]
        public LocationType? LocationType { get; set; }

        /// <summary>
        /// The ID of the parent station if this location is part of a larger station.
        /// (Optional/Required for specific LocationTypes)
        /// </summary>
        [GtfsProperty("parent_station", 9)]
        public string ParentStation { get; set; }

        /// <summary>
        /// Timezone of the location. If omitted, the agency's timezone is used.
        /// (Optional)
        /// </summary>
        [GtfsProperty("stop_timezone", 10)]
        public string StopTimezone { get; set; }

        /// <summary>
        /// Indicates whether wheelchair boarding is possible from the location.
        /// References the <see cref="WheelchairBoarding"/> enum.
        /// (Optional)
        /// </summary>
        [GtfsProperty("wheelchair_boarding", 11)]
        public WheelchairBoarding? WheelchairBoarding { get; set; }
    }
}