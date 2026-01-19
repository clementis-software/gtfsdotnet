using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates the type of fare product based on its duration or usage limit.
    /// Part of the GTFS Fares V2 extension.
    /// </summary>
    [GtfsEnum]
    public enum FareProductType
    {
        /// <summary>
        /// A fare product valid for a single journey or a limited number of transfers.
        /// </summary>
        SingleRide = 0,

        /// <summary>
        /// A pass valid for unlimited travel within a single day.
        /// </summary>
        DayPass = 1,

        /// <summary>
        /// A pass valid for unlimited travel within a seven-day period.
        /// </summary>
        WeeklyPass = 2,

        /// <summary>
        /// A pass valid for unlimited travel within a calendar month or a 30-day period.
        /// </summary>
        MonthlyPass = 3,

        /// <summary>
        /// A pass valid for unlimited travel for an entire year.
        /// </summary>
        AnnualPass = 4,

        /// <summary>
        /// A fare product that does not fit into the standard duration categories.
        /// </summary>
        Other = 5
    }
}