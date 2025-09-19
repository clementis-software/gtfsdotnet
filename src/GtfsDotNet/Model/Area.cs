using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("areas.txt")]
    public class Area : GtfsDataItem
    {
        [GtfsProperty("area_id", 0)]
        public string AreaId { get; set; }

        [GtfsProperty("area_name", 1)]
        public string AreaName { get; set; }

        [GtfsProperty("area_desc", 2)]
        public string AreaDesc { get; set; }
    }

}
