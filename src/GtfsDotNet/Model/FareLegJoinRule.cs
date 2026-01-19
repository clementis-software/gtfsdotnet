using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Defines rules for joining fare legs together to form a journey.
    /// Part of the GTFS Fares V2 extension, used to model complex transfer and journey-based pricing.
    /// </summary>
    [GtfsFile("fare_leg_join_rules.txt")]
    public class FareLegJoinRule : GtfsDataItem
    {
        /// <summary>
        /// Identifies a fare leg join rule. The ID must be unique within the dataset.
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_leg_join_rule_id", 0)]
        [GtfsId]
        public string FareLegJoinRuleId { get; set; }

        /// <summary>
        /// Identifies the fare leg rule that results from joining two other legs.
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_leg_rule_id", 1)]
        [GtfsReference<FareLegRule>]
        public string FareLegRuleId { get; set; }

        [GtfsReferenceProperty(nameof(FareLegRuleId))]
        public FareLegRule FareLegRule { get; set; }

        /// <summary>
        /// Identifies the first fare leg rule in a sequence of two legs to be joined.
        /// (Optional)
        /// </summary>
        [GtfsProperty("from_fare_leg_rule_id", 2)]
        [GtfsReference<FareLegRule>]
        public string FromFareLegRuleId { get; set; }

        [GtfsReferenceProperty(nameof(FromFareLegRuleId))]
        public FareLegRule FromFareLegRule { get; set; }

        /// <summary>
        /// Identifies the second fare leg rule in a sequence of two legs to be joined.
        /// (Optional)
        /// </summary>
        [GtfsProperty("to_fare_leg_rule_id", 3)]
        [GtfsReference<FareLegRule>]
        public string ToFareLegRuleId { get; set; }

        [GtfsReferenceProperty(nameof(ToFareLegRuleId))]
        public FareLegRule ToFareLegRule { get; set; }
    }
}