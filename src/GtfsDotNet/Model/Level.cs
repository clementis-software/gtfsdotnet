using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("levels.txt")]
    public class Level : GtfsDataItem
    {
        [GtfsProperty("level_id", 0)]
        public string LevelId { get; set; }

        [GtfsProperty("level_index", 1)]
        public double LevelIndex { get; set; }

        [GtfsProperty("level_name", 2)]
        public string LevelName { get; set; }
    }

}
