using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents a scheduled arrival and departure for a specific stop on a specific trip.
    /// Corresponds to the stop_times.txt file.
    /// </summary>
    [GtfsFile("stop_times.txt")]
    public class StopTime : GtfsDataItem
    {
        /// <summary>
        /// Identifies the trip. References <see cref="Trip.TripId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("trip_id", 0)]
        [GtfsReference<Trip>]
        public string TripId { get; set; }

        [GtfsReferenceProperty(nameof(TripId))]
        public Trip Trip { get; set; }

        /// <summary>
        /// Arrival time in HH:MM:SS format. For times after midnight, the hour can exceed 24 (e.g., 25:30:00).
        /// (Required for the first and last stop of a trip)
        /// </summary>
        [GtfsProperty("arrival_time", 1)]
        public TimeSpan? ArrivalTime { get; set; }

        /// <summary>
        /// Departure time in HH:MM:SS format.
        /// (Required for the first and last stop of a trip)
        /// </summary>
        [GtfsProperty("departure_time", 2)]
        public TimeSpan? DepartureTime { get; set; }

        /// <summary>
        /// Identifies the stop. References <see cref="Stop.StopId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("stop_id", 3)]
        [GtfsReference<Stop>]
        public string StopId
        {
            get; set
            {
                if (field != value)
                {
                    Stop = null;
                    field = value;
                }
            }
        }

        [GtfsReferenceProperty(nameof(StopId))]
        public Stop Stop { get; set; }

        /// <summary>
        /// Order of stops for a particular trip. Values must increase along the trip.
        /// (Required)
        /// </summary>
        [GtfsProperty("stop_sequence", 4)]
        public int StopSequence { get; set; }

        /// <summary>
        /// Text displayed to riders that describes the destination of the trip from this stop.
        /// Overrides the trip_headsign in trips.txt.
        /// (Optional)
        /// </summary>
        [GtfsProperty("stop_headsign", 5)]
        public string StopHeadSign { get; set; }

        /// <summary>
        /// Indicates whether passengers are picked up at this stop.
        /// References the <see cref="PickupDropOffType"/> enum.
        /// (Optional)
        /// </summary>
        [GtfsProperty("pickup_type", 6)]
        public PickupDropOffType? PickupType { get; set; }

        /// <summary>
        /// Indicates whether passengers are dropped off at this stop.
        /// References the <see cref="PickupDropOffType"/> enum.
        /// (Optional)
        /// </summary>
        [GtfsProperty("drop_off_type", 7)]
        public PickupDropOffType? DropOffType { get; set; }

        /// <summary>
        /// Actual distance traveled along the shape from the start of the trip to this stop.
        /// Must be consistent with shapes.txt.
        /// (Optional)
        /// </summary>
        [GtfsProperty("shape_dist_traveled", 8)]
        public double? ShapeDistanceTraveled { get; set; }

        /// <summary>
        /// Indicates if arrival/departure times are exact or approximate.
        /// 0: Approximate times.
        /// 1: Exact times (Timepoint).
        /// (Optional)
        /// </summary>
        [GtfsProperty("timepoint", 9)]
        public int? Timepoint { get; set; }
    }
}