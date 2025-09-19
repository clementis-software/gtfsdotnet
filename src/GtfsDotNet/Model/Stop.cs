using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("stops.txt")]
    public class Stop : GtfsDataItem
    {
        [GtfsProperty("stop_id", 0)]
        public string StopId { get; set; }

        [GtfsProperty("stop_code", 1)]
        public string StopCode { get; set; }

        [GtfsProperty("stop_name", 2)]
        public string StopName { get; set; }

        [GtfsProperty("stop_desc", 3)]
        public string StopDescription { get; set; }

        [GtfsProperty("stop_lat", 4)]
        public double Latitude { get; set; }

        [GtfsProperty("stop_lon", 5)]
        public double Longitude { get; set; }

        [GtfsProperty("zone_id", 6)]
        public string ZoneId { get; set; }

        [GtfsProperty("stop_url", 7)]
        public string StopUrl { get; set; }

        [GtfsProperty("location_type", 8)]
        public LocationType? LocationType { get; set; }

        [GtfsProperty("parent_station", 9)]
        public string ParentStation { get; set; }

        [GtfsProperty("stop_timezone", 10)]
        public string StopTimezone { get; set; }

        [GtfsProperty("wheelchair_boarding", 11)]
        public WheelchairBoarding? WheelchairBoarding { get; set; }
    }
}
