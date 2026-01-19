using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Describes levels within a station. 
    /// This is used to represent multiple floors or layers of a transit hub.
    /// </summary>
    [GtfsFile("levels.txt")]
    public class Level : GtfsDataItem
    {
        /// <summary>
        /// Identifies the level. This ID is used in stops.txt to associate a stop or station with a specific floor.
        /// (Required)
        /// </summary>
        [GtfsProperty("level_id", 0)]
        [GtfsId]
        public string LevelId { get; set; }

        /// <summary>
        /// Numeric index of the level. Higher numbers are higher up. 
        /// Ground level should be 0. Basements should be negative numbers.
        /// (Required)
        /// </summary>
        [GtfsProperty("level_index", 1)]
        public double LevelIndex { get; set; }

        /// <summary>
        /// Full name of the level (e.g., "Concourse", "Mezzanine", "Platform Level").
        /// (Optional)
        /// </summary>
        [GtfsProperty("level_name", 2)]
        public string LevelName { get; set; }
    }
}