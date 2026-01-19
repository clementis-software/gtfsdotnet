using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Defines booking rules for on-demand or flexible transit services.
    /// Corresponds to the booking_rules.txt file.
    /// </summary>
    [GtfsFile("booking_rules.txt")]
    public class BookingRule : GtfsDataItem
    {
        /// <summary>
        /// Identifies a booking rule. Unique within the dataset.
        /// (Required)
        /// </summary>
        [GtfsProperty("booking_rule_id", 0)]
        [GtfsId]
        public string BookingRuleId { get; set; }

        /// <summary>
        /// Identifies a starting stop for the booking rule.
        /// (Optional)
        /// </summary>
        [GtfsProperty("from_stop_id", 1)]
        [GtfsReference<Stop>]
        public string FromStopId { get; set; }

        [GtfsReferenceProperty(nameof(FromStopId))]
        public Stop FromStop { get; set; }

        /// <summary>
        /// Identifies an ending stop for the booking rule.
        /// (Optional)
        /// </summary>
        [GtfsProperty("to_stop_id", 2)]
        [GtfsReference<Stop>]
        public string ToStopId { get; set; }

        [GtfsReferenceProperty(nameof(ToStopId))]
        public Stop ToStop { get; set; }

        /// <summary>
        /// Identifies a starting area for the booking rule.
        /// (Optional)
        /// </summary>
        [GtfsProperty("from_area_id", 3)]
        [GtfsReference<Area>]
        public string FromAreaId { get; set; }

        [GtfsReferenceProperty(nameof(FromAreaId))]
        public Area FromArea { get; set; }

        /// <summary>
        /// Identifies an ending area for the booking rule.
        /// (Optional)
        /// </summary>
        [GtfsProperty("to_area_id", 4)]
        [GtfsReference<Area>]
        public string ToAreaId { get; set; }

        [GtfsReferenceProperty(nameof(ToAreaId))]
        public Area ToArea { get; set; }

        /// <summary>
        /// Identifies a starting location (e.g. from locations.geojson) for the booking rule.
        /// (Optional)
        /// </summary>
        [GtfsProperty("from_location_id", 5)]
        public string FromLocationId { get; set; }

        /// <summary>
        /// Identifies an ending location for the booking rule.
        /// (Optional)
        /// </summary>
        [GtfsProperty("to_location_id", 6)]
        public string ToLocationId { get; set; }

        /// <summary>
        /// Identifies the booking contact information.
        /// (Optional)
        /// </summary>
        [GtfsProperty("booking_contact_id", 7)]
        public string BookingContactId { get; set; }

        /// <summary>
        /// Time of day when the booking rule starts being in effect (HH:MM:SS).
        /// (Optional)
        /// </summary>
        [GtfsProperty("booking_time", 8)]
        public string BookingTime { get; set; }

        /// <summary>
        /// Maximum time before the trip starts that a booking can be made.
        /// (Optional)
        /// </summary>
        [GtfsProperty("max_booking_time", 9)]
        public string MaxBookingTime { get; set; }

        /// <summary>
        /// Minimum time before the trip starts that a booking must be made.
        /// (Optional)
        /// </summary>
        [GtfsProperty("min_booking_time", 10)]
        public string MinBookingTime { get; set; }

        /// <summary>
        /// Indicates whether a booking is required for the service.
        /// 0 - Booking is required.
        /// 1 - Booking is not required.
        /// (Required)
        /// </summary>
        [GtfsProperty("requires_booking", 11)]
        public int RequiresBooking { get; set; }
    }
}