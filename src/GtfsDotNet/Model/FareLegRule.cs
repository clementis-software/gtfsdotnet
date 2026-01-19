using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Defines the rules for a fare leg. Fare legs are the individual segments of a journey 
    /// that are priced together under Fares V2.
    /// Corresponds to the fare_leg_rules.txt file.
    /// </summary>
    [GtfsFile("fare_leg_rules.txt")]
    public class FareLegRule : GtfsDataItem
    {
        /// <summary>
        /// Identifies a fare leg rule. The ID must be unique within the dataset.
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_leg_rule_id", 0)]
        [GtfsId]
        public string FareLegRuleId { get; set; }

        /// <summary>
        /// Identifies the group of timeframes when the fare leg starts.
        /// References a group_id in timeframes.txt.
        /// (Optional)
        /// </summary>
        [GtfsProperty("from_timeframe_group_id", 1)]
        public string FromTimeframeGroupId { get; set; }

        /// <summary>
        /// Identifies the group of timeframes when the fare leg ends.
        /// References a group_id in timeframes.txt.
        /// (Optional)
        /// </summary>
        [GtfsProperty("to_timeframe_group_id", 2)]
        public string ToTimeframeGroupId { get; set; }

        /// <summary>
        /// Identifies the rider category that applies at the start of the fare leg.
        /// References rider_categories.txt.
        /// (Optional)
        /// </summary>
        [GtfsProperty("from_rider_category_id", 3)]
        [GtfsReference<RiderCategory>]
        public string FromRiderCategoryId { get; set; }

        /// <summary>
        /// Identifies the rider category that applies at the end of the fare leg.
        /// References rider_categories.txt.
        /// (Optional)
        /// </summary>
        [GtfsProperty("to_rider_category_id", 4)]
        [GtfsReference<RiderCategory>]
        public string ToRiderCategoryId { get; set; }

        /// <summary>
        /// Identifies the fare media or product that applies to this leg.
        /// References fare_products.txt.
        /// (Optional)
        /// </summary>
        [GtfsProperty("fare_id", 5)]
        [GtfsReference<FareProduct>]
        public string FareId { get; set; }

        [GtfsReferenceProperty(nameof(FareId))]
        public FareProduct FareProduct { get; set; }
    }
}