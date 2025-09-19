using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("location_group_stops.txt")]
    public class LocationGroupStop : GtfsDataItem
    {
        [GtfsProperty("location_group_id", 0)]
        public string LocationGroupId { get; set; }

        [GtfsProperty("stop_id", 1)]
        public string StopId { get; set; }
    }

}
