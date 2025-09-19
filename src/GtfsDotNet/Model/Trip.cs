using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("trips.txt")]
    public class Trip : GtfsDataItem
    {
        [GtfsProperty("route_id", 0)]
        public string RouteId { get; set; }

        [GtfsProperty("service_id", 1)]
        public string ServiceId { get; set; }

        [GtfsProperty("trip_id", 2)]
        public string TripId { get; set; }

        [GtfsProperty("trip_headsign", 3)]
        public string HeadSign { get; set; }

        [GtfsProperty("trip_short_name", 4)]
        public string ShortName { get; set; }

        [GtfsProperty("direction_id", 5)]
        public Direction? DirectionId { get; set; }

        [GtfsProperty("block_id", 6)]
        public string BlockId { get; set; }

        [GtfsProperty("shape_id", 7)]
        public string ShapeId { get; set; }

        [GtfsProperty("wheelchair_accessible", 8)]
        public WheelchairAccessibility? WheelchairAccessible { get; set; }

        [GtfsProperty("bikes_allowed", 9)]
        public BikesAllowed? BikesAllowed { get; set; }
    }


}
