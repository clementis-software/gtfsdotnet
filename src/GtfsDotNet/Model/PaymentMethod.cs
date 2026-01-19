using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates when the fare must be paid for a specific fare attribute.
    /// Used in the Fares V1 specification (fare_attributes.txt).
    /// </summary>
    [GtfsEnum]
    public enum PaymentMethod
    {
        /// <summary>
        /// Fare is paid on board the vehicle (e.g., to the driver or via a conductor).
        /// </summary>
        OnBoard = 0,

        /// <summary>
        /// Fare must be paid before boarding the vehicle (e.g., at a ticket machine, online, or at a counter).
        /// </summary>
        BeforeBoarding = 1
    }
}