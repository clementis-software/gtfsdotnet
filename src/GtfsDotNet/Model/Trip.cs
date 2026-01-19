using GtfsDotNet.Attributes;
using System.Collections.ObjectModel;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Represents a specific journey taken by a vehicle. 
    /// A trip occurs on a specific route and follows a set of stop times.
    /// </summary>
    [GtfsFile("trips.txt")]
    public class Trip : GtfsDataItem
    {
        /// <summary>
        /// Identifies the route the trip belongs to. References <see cref="Route.RouteId"/>.
        /// (Required)
        /// </summary>
        [GtfsProperty("route_id", 0)]
        [GtfsReference<Route>]
        public string RouteId { get; set; }

        [GtfsReferenceProperty(nameof(RouteId))]
        public Route Route { get; set; }

        /// <summary>
        /// Identifies a set of dates when service is available for this trip. 
        /// References service_id in calendar.txt or calendar_dates.txt.
        /// (Required)
        /// </summary>
        [GtfsProperty("service_id", 1)]
        public string ServiceId { get; set; }

        /// <summary>
        /// Uniquely identifies the trip across the dataset.
        /// (Required)
        /// </summary>
        [GtfsProperty("trip_id", 2)]
        [GtfsId]
        public string TripId { get; set; }

        /// <summary>
        /// The destination text displayed to passengers (e.g., "Airport").
        /// (Optional)
        /// </summary>
        [GtfsProperty("trip_headsign", 3)]
        public string HeadSign { get; set; }

        /// <summary>
        /// A short name that identifies the specific trip (e.g., a flight or train number).
        /// (Optional)
        /// </summary>
        [GtfsProperty("trip_short_name", 4)]
        public string ShortName { get; set; }

        /// <summary>
        /// Indicates the direction of travel for the trip.
        /// References the <see cref="Direction"/> enum.
        /// (Optional)
        /// </summary>
        [GtfsProperty("direction_id", 5)]
        public Direction? Direction { get; set; }

        /// <summary>
        /// Identifies the block to which the trip belongs. A block consists of a series of 
        /// sequential trips made by the same vehicle.
        /// (Optional)
        /// </summary>
        [GtfsProperty("block_id", 6)]
        public string BlockId { get; set; }

        /// <summary>
        /// Identifies the shape of the trip. References <see cref="Shape.ShapeId"/>.
        /// (Optional)
        /// </summary>
        [GtfsProperty("shape_id", 7)]
        [GtfsReference<Shape>]
        public string ShapeId { get; set; }

        /// <summary>
        /// Indicates if the vehicle used for this trip can accommodate wheelchairs.
        /// References the <see cref="WheelchairAccessibility"/> enum.
        /// (Optional)
        /// </summary>
        [GtfsProperty("wheelchair_accessible", 8)]
        public WheelchairAccessibility? WheelchairAccessible { get; set; }

        /// <summary>
        /// Indicates if bicycles are allowed on this trip.
        /// References the <see cref="BikesAllowed"/> enum.
        /// (Optional)
        /// </summary>
        [GtfsProperty("bikes_allowed", 9)]
        public BikesAllowed? BikesAllowed { get; set; }

        [GtfsChildCollection(nameof(StopTime.TripId))]
        public ICollection<StopTime> StopTimes { get; set; }
    }
}