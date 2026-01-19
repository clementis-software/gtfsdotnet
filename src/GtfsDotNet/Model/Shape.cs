using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents a point in a shape that outlines the path taken by a vehicle.
    /// Shapes are used to draw the route line on a map.
    /// </summary>
    [GtfsFile("shapes.txt")]
    public class Shape : GtfsDataItem
    {
        /// <summary>
        /// Identifies the shape. Multiple rows with the same ID form a single path.
        /// Referenced by trips.txt.
        /// (Required)
        /// </summary>
        [GtfsProperty("shape_id", 0)]
        public string ShapeId { get; set; }

        /// <summary>
        /// Latitude of a shape point.
        /// (Required)
        /// </summary>
        [GtfsProperty("shape_pt_lat", 1)]
        public double ShapePointLatitude { get; set; }

        /// <summary>
        /// Longitude of a shape point.
        /// (Required)
        /// </summary>
        [GtfsProperty("shape_pt_lon", 2)]
        public double ShapePointLongitude { get; set; }

        /// <summary>
        /// The sequence in which the shape points connect to form the path.
        /// Values must increase for each successive point in a shape.
        /// (Required)
        /// </summary>
        [GtfsProperty("shape_pt_sequence", 3)]
        public int ShapePointSequence { get; set; }

        /// <summary>
        /// Actual distance traveled along the shape from the first point to this point.
        /// Helps routing engines to snap stop locations accurately onto the shape.
        /// (Optional)
        /// </summary>
        [GtfsProperty("shape_dist_traveled", 4)]
        public double? ShapeDistanceTraveled { get; set; }
    }
}