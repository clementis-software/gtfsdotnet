using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Defines a group of locations (stops, stations, or areas) that are treated as a single unit for fare calculation.
    /// Part of the GTFS Fares V2 extension.
    /// </summary>
    [GtfsFile("location_groups.txt")]
    public class LocationGroup : GtfsDataItem
    {
        /// <summary>
        /// Identifies a location group. The ID must be unique within the dataset.
        /// Referenced by other files to apply fare rules to the entire group.
        /// (Required)
        /// </summary>
        [GtfsProperty("location_group_id", 0)]
        [GtfsId]
        public string LocationGroupId { get; set; }

        /// <summary>
        /// Name of the location group as displayed to riders (e.g., "City Center Zone").
        /// (Optional)
        /// </summary>
        [GtfsProperty("location_group_name", 1)]
        public string LocationGroupName { get; set; }

        /// <summary>
        /// Description of the location group to help distinguish it from others.
        /// (Optional)
        /// </summary>
        [GtfsProperty("location_group_desc", 2)]
        public string LocationGroupDescription { get; set; }
    }
}