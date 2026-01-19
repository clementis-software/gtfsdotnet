using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Service dates specified using a weekly schedule with start and end dates.
    /// This file is required unless all service dates are defined in calendar_dates.txt.
    /// </summary>
    [GtfsFile("calendar.txt")]
    public class Calendar : GtfsDataItem
    {
        /// <summary>
        /// Uniquely identifies a set of dates when service is available for one or more routes.
        /// (Required)
        /// </summary>
        [GtfsProperty("service_id", 0)]
        public string ServiceId { get; set; }

        /// <summary>
        /// Indicates whether the service operates on all Mondays in the date range.
        /// 1 - Service is available.
        /// 0 - Service is not available.
        /// (Required)
        /// </summary>
        [GtfsProperty("monday", 1)]
        public int Monday { get; set; }

        /// <summary>
        /// Indicates whether the service operates on all Tuesdays in the date range.
        /// 1 - Service is available.
        /// 0 - Service is not available.
        /// (Required)
        /// </summary>
        [GtfsProperty("tuesday", 2)]
        public int Tuesday { get; set; }

        /// <summary>
        /// Indicates whether the service operates on all Wednesdays in the date range.
        /// 1 - Service is available.
        /// 0 - Service is not available.
        /// (Required)
        /// </summary>
        [GtfsProperty("wednesday", 3)]
        public int Wednesday { get; set; }

        /// <summary>
        /// Indicates whether the service operates on all Thursdays in the date range.
        /// 1 - Service is available.
        /// 0 - Service is not available.
        /// (Required)
        /// </summary>
        [GtfsProperty("thursday", 4)]
        public int Thursday { get; set; }

        /// <summary>
        /// Indicates whether the service operates on all Fridays in the date range.
        /// 1 - Service is available.
        /// 0 - Service is not available.
        /// (Required)
        /// </summary>
        [GtfsProperty("friday", 5)]
        public int Friday { get; set; }

        /// <summary>
        /// Indicates whether the service operates on all Saturdays in the date range.
        /// 1 - Service is available.
        /// 0 - Service is not available.
        /// (Required)
        /// </summary>
        [GtfsProperty("saturday", 6)]
        public int Saturday { get; set; }

        /// <summary>
        /// Indicates whether the service operates on all Sundays in the date range.
        /// 1 - Service is available.
        /// 0 - Service is not available.
        /// (Required)
        /// </summary>
        [GtfsProperty("sunday", 7)]
        public int Sunday { get; set; }

        /// <summary>
        /// Start service day for the service interval in YYYYMMDD format.
        /// (Required)
        /// </summary>
        [GtfsProperty("start_date", 8)]
        public string StartDate { get; set; }

        /// <summary>
        /// End service day for the service interval in YYYYMMDD format.
        /// This day is included in the interval.
        /// (Required)
        /// </summary>
        [GtfsProperty("end_date", 9)]
        public string EndDate { get; set; }
    }
}