using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Defines how a fare (from fare_attributes.txt) applies to a specific route, 
    /// origin-destination pair, or transit zones.
    /// Corresponds to the fare_rules.txt file.
    /// </summary>
    [GtfsFile("fare_rules.txt")]
    public class FareRule : GtfsDataItem
    {
        /// <summary>
        /// Identifies a fare class. References <see cref="Fare.FareId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("fare_id", 0)]
        [GtfsReference<Fare>]
        public string FareId { get; set; }

        /// <summary>
        /// Identifies a route associated with the fare class.
        /// If provided, the fare applies only to the specified route.
        /// (Optional)
        /// </summary>
        [GtfsProperty("route_id", 1)]
        [GtfsReference<Route>]
        public string RouteId { get; set; }

        /// <summary>
        /// Identifies the origin zone for the fare. References <see cref="Stop.ZoneId"/>.
        /// (Optional)
        /// </summary>
        [GtfsProperty("origin_id", 2)]
        public string OriginId { get; set; }

        /// <summary>
        /// Identifies the destination zone for the fare. References <see cref="Stop.ZoneId"/>.
        /// (Optional)
        /// </summary>
        [GtfsProperty("destination_id", 3)]
        public string DestinationId { get; set; }

        /// <summary>
        /// Identifies a zone that the itinerary must pass through for the fare to apply.
        /// (Optional)
        /// </summary>
        [GtfsProperty("contains_id", 4)]
        public string ContainsId { get; set; }
    }
}