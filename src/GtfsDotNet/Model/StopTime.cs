using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("stop_times.txt")]
    public class StopTime : GtfsDataItem
    {
        [GtfsProperty("trip_id", 0)]
        public string TripId { get; set; }

        [GtfsProperty("arrival_time", 1)]
        public string ArrivalTime { get; set; }

        [GtfsProperty("departure_time", 2)]
        public string DepartureTime { get; set; }

        [GtfsProperty("stop_id", 3)]
        public string StopId { get; set; }

        [GtfsProperty("stop_sequence", 4)]
        public int StopSequence { get; set; }

        [GtfsProperty("stop_headsign", 5)]
        public string StopHeadSign { get; set; }

        [GtfsProperty("pickup_type", 6)]
        public PickupDropOffType? PickupType { get; set; }

        [GtfsProperty("drop_off_type", 7)]
        public PickupDropOffType? DropOffType { get; set; }

        [GtfsProperty("shape_dist_traveled", 8)]
        public double? ShapeDistanceTraveled { get; set; }

        [GtfsProperty("timepoint", 9)]
        public int? Timepoint { get; set; }
    }

}
