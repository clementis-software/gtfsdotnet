using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("rider_categories.txt")]
    public class RiderCategory : GtfsDataItem
    {
        [GtfsProperty("rider_category_id", 0)]
        public string RiderCategoryId { get; set; }

        [GtfsProperty("rider_category_name", 1)]
        public string RiderCategoryName { get; set; }

        [GtfsProperty("rider_category_desc", 2)]
        public string RiderCategoryDesc { get; set; }
    }

}
