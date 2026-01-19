using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Exceptions for the services defined in the calendar.txt file. 
    /// If calendar.txt is omitted, then calendar_dates.txt must contain all dates of service.
    /// </summary>
    [GtfsFile("calendar_dates.txt")]
    public class CalendarDate : GtfsDataItem
    {
        /// <summary>
        /// Identifies a set of dates when service is available for one or more routes. 
        /// Each service_id value must appear at least once in calendar.txt or calendar_dates.txt.
        /// (Required)
        /// </summary>
        [GtfsProperty("service_id", 0)]
        public string ServiceId { get; set; }

        /// <summary>
        /// Specifies a date when service exception occurs in YYYYMMDD format.
        /// (Required)
        /// </summary>
        [GtfsProperty("date", 1)]
        public string Date { get; set; }

        /// <summary>
        /// Indicates whether service is available on the date specified in the date field.
        /// (Required)
        /// </summary>
        [GtfsProperty("exception_type", 2)]
        public ExceptionType ExceptionType { get; set; }
    }
}