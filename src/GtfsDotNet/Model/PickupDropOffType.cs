using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates how passengers are picked up or dropped off at a specific stop.
    /// Used in stop_times.txt (pickup_type, drop_off_type) and routes.txt (continuous_pickup, continuous_drop_off).
    /// </summary>
    [GtfsEnum]
    public enum PickupDropOffType
    {
        /// <summary>
        /// Regularly scheduled pickup or drop off.
        /// </summary>
        Regular = 0,

        /// <summary>
        /// No pickup or drop off available at this stop.
        /// Used for stops that the vehicle passes but does not allow passengers to use.
        /// </summary>
        NotAvailable = 1,

        /// <summary>
        /// Must phone the agency to arrange pickup or drop off.
        /// Often used for Demand Responsive Transport (DRT) or "Rufbus" systems.
        /// </summary>
        MustPhoneAgency = 2,

        /// <summary>
        /// Must coordinate with the driver to arrange pickup or drop off.
        /// Often used for flag-stop areas or flexible service zones.
        /// </summary>
        MustCoordinateWithDriver = 3
    }
}