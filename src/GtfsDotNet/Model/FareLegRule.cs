using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("fare_leg_rules.txt")]
    public class FareLegRule : GtfsDataItem
    {
        [GtfsProperty("fare_leg_rule_id", 0)]
        public string FareLegRuleId { get; set; }

        [GtfsProperty("from_timeframe_group_id", 1)]
        public string FromTimeframeGroupId { get; set; }

        [GtfsProperty("to_timeframe_group_id", 2)]
        public string ToTimeframeGroupId { get; set; }

        [GtfsProperty("from_rider_category_id", 3)]
        public string FromRiderCategoryId { get; set; }

        [GtfsProperty("to_rider_category_id", 4)]
        public string ToRiderCategoryId { get; set; }

        [GtfsProperty("fare_id", 5)]
        public string FareId { get; set; }
    }
}
