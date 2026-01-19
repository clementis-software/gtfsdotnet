using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates whether service is added or removed on a specific date in calendar_dates.txt.
    /// </summary>
    [GtfsEnum]
    public enum ExceptionType
    {
        /// <summary>
        /// Service has been added for the specified date.
        /// </summary>
        ServiceAdded = 1,

        /// <summary>
        /// Service has been removed for the specified date.
        /// </summary>
        ServiceRemoved = 2
    }
}