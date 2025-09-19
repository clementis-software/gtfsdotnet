using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("stop_areas.txt")]
    public class StopArea : GtfsDataItem
    {
        [GtfsProperty("stop_area_id", 0)]
        public string StopAreaId { get; set; }

        [GtfsProperty("stop_id", 1)]
        public string StopId { get; set; }

        [GtfsProperty("area_id", 2)]
        public string AreaId { get; set; }
    }

}
