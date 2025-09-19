using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("fare_transfer_rules.txt")]
    public class FareTransferRule : GtfsDataItem
    {
        [GtfsProperty("fare_transfer_rule_id", 0)]
        public string FareTransferRuleId { get; set; }

        [GtfsProperty("from_stop_id", 1)]
        public string FromStopId { get; set; }

        [GtfsProperty("to_stop_id", 2)]
        public string ToStopId { get; set; }

        [GtfsProperty("from_route_id", 3)]
        public string FromRouteId { get; set; }

        [GtfsProperty("to_route_id", 4)]
        public string ToRouteId { get; set; }

        [GtfsProperty("from_trip_id", 5)]
        public string FromTripId { get; set; }

        [GtfsProperty("to_trip_id", 6)]
        public string ToTripId { get; set; }

        [GtfsProperty("min_transfer_time", 7)]
        public int MinTransferTime { get; set; }
    }

}
