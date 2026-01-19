using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Identifies an area or a group of locations.
    /// Used in Fares V2 to define complex fare areas that can include multiple stops or locations.
    /// </summary>
    [GtfsFile("areas.txt")]
    public class Area : GtfsDataItem
    {
        /// <summary>
        /// Identifies an area. The area_id must be unique within the dataset.
        /// Used by other files (like stop_areas.txt) to associate locations with this area.
        /// (Required)
        /// </summary>
        [GtfsProperty("area_id", 0)]
        [GtfsId]
        public string AreaId { get; set; }

        /// <summary>
        /// Full name of the area as displayed to riders.
        /// (Optional)
        /// </summary>
        [GtfsProperty("area_name", 1)]
        public string AreaName { get; set; }

        /// <summary>
        /// Description of the area to help distinguish it from others.
        /// (Optional)
        /// </summary>
        [GtfsProperty("area_desc", 2)]
        public string AreaDescription { get; set; }
    }
}