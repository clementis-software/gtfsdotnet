using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents a category of riders (e.g., Senior, Child, Student) used to define 
    /// specific fare prices in Fares V2.
    /// Corresponds to the rider_categories.txt file.
    /// </summary>
    [GtfsFile("rider_categories.txt")]
    public class RiderCategory : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies a rider category. This ID is referenced in fare_leg_rules.txt.
        /// (Required)
        /// </summary>
        [GtfsProperty("rider_category_id", 0)]
        [GtfsId]
        public string RiderCategoryId { get; set; }

        /// <summary>
        /// Name of the rider category as displayed to passengers (e.g., "Senior", "Youth").
        /// (Optional)
        /// </summary>
        [GtfsProperty("rider_category_name", 1)]
        public string RiderCategoryName { get; set; }

        /// <summary>
        /// Description of the rider category, which may include eligibility requirements 
        /// (e.g., "Ages 65+", "Full-time students with ID").
        /// (Optional)
        /// </summary>
        [GtfsProperty("rider_category_desc", 2)]
        public string RiderCategoryDescription { get; set; }
    }
}