using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("booking_rules.txt")]
    public class BookingRule : GtfsDataItem
    {
        [GtfsProperty("booking_rule_id", 0)]
        public string BookingRuleId { get; set; }

        [GtfsProperty("from_stop_id", 1)]
        public string FromStopId { get; set; }

        [GtfsProperty("to_stop_id", 2)]
        public string ToStopId { get; set; }

        [GtfsProperty("from_area_id", 3)]
        public string FromAreaId { get; set; }

        [GtfsProperty("to_area_id", 4)]
        public string ToAreaId { get; set; }

        [GtfsProperty("from_location_id", 5)]
        public string FromLocationId { get; set; }

        [GtfsProperty("to_location_id", 6)]
        public string ToLocationId { get; set; }

        [GtfsProperty("booking_contact_id", 7)]
        public string BookingContactId { get; set; }

        [GtfsProperty("booking_time", 8)]
        public string BookingTime { get; set; }

        [GtfsProperty("max_booking_time", 9)]
        public string MaxBookingTime { get; set; }

        [GtfsProperty("min_booking_time", 10)]
        public string MinBookingTime { get; set; }

        [GtfsProperty("requires_booking", 11)]
        public int RequiresBooking { get; set; }
    }
}
