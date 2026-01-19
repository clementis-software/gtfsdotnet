using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Defines the rules for transfers between fare legs.
    /// Part of the GTFS Fares V2 extension, used to model how costs change when switching vehicles.
    /// </summary>
    [GtfsFile("fare_transfer_rules.txt")]
    public class FareTransferRule : GtfsDataItem
    {
        /// <summary>
        /// Identifies a fare transfer rule. The ID must be unique within the dataset.
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_transfer_rule_id", 0)]
        [GtfsId]
        public string FareTransferRuleId { get; set; }

        /// <summary>
        /// Identifies the stop where the transfer begins.
        /// (Optional)
        /// </summary>
        [GtfsProperty("from_stop_id", 1)]
        [GtfsReference<Stop>]
        public string FromStopId { get; set; }

        /// <summary>
        /// Identifies the stop where the transfer ends.
        /// (Optional)
        /// </summary>
        [GtfsProperty("to_stop_id", 2)]
        [GtfsReference<Stop>]
        public string ToStopId { get; set; }

        /// <summary>
        /// Identifies the route from which the rider is transferring.
        /// (Optional)
        /// </summary>
        [GtfsProperty("from_route_id", 3)]
        [GtfsReference<Route>]
        public string FromRouteId { get; set; }

        /// <summary>
        /// Identifies the route to which the rider is transferring.
        /// (Optional)
        /// </summary>
        [GtfsProperty("to_route_id", 4)]
        [GtfsReference<Route>]
        public string ToRouteId { get; set; }

        /// <summary>
        /// Identifies the specific trip from which the rider is transferring.
        /// (Optional)
        /// </summary>
        [GtfsProperty("from_trip_id", 5)]
        [GtfsReference<Trip>]
        public string FromTripId { get; set; }

        /// <summary>
        /// Identifies the specific trip to which the rider is transferring.
        /// (Optional)
        /// </summary>
        [GtfsProperty("to_trip_id", 6)]
        [GtfsReference<Trip>]
        public string ToTripId { get; set; }

        /// <summary>
        /// Minimum time in seconds that must pass between the arrival of the first leg 
        /// and the departure of the second leg for this rule to apply.
        /// (Optional)
        /// </summary>
        [GtfsProperty("min_transfer_time", 7)]
        public int MinTransferTime { get; set; }
    }
}