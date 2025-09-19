using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("location_groups.txt")]
    public class LocationGroup : GtfsDataItem
    {
        [GtfsProperty("location_group_id", 0)]
        public string LocationGroupId { get; set; }

        [GtfsProperty("location_group_name", 1)]
        public string LocationGroupName { get; set; }

        [GtfsProperty("location_group_desc", 2)]
        public string LocationGroupDesc { get; set; }
    }

}
