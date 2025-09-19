using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("fare_leg_join_rules.txt")]
    public class FareLegJoinRule : GtfsDataItem
    {
        [GtfsProperty("fare_leg_join_rule_id", 0)]
        public string FareLegJoinRuleId { get; set; }

        [GtfsProperty("fare_leg_rule_id", 1)]
        public string FareLegRuleId { get; set; }

        [GtfsProperty("from_fare_leg_rule_id", 2)]
        public string FromFareLegRuleId { get; set; }

        [GtfsProperty("to_fare_leg_rule_id", 3)]
        public string ToFareLegRuleId { get; set; }
    }

}
