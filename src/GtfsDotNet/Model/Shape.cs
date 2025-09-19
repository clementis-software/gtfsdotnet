using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("shapes.txt")]
    public class Shape : GtfsDataItem
    {
        [GtfsProperty("shape_id", 0)]
        public string ShapeId { get; set; }

        [GtfsProperty("shape_pt_lat", 1)]
        public double ShapePtLat { get; set; }

        [GtfsProperty("shape_pt_lon", 2)]
        public double ShapePtLon { get; set; }

        [GtfsProperty("shape_pt_sequence", 3)]
        public int ShapePtSequence { get; set; }

        [GtfsProperty("shape_dist_traveled", 4)]
        public double? ShapeDistTraveled { get; set; }
    }

}
