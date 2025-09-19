using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("calendar_dates.txt")]
    public class CalendarDate : GtfsDataItem
    {
        [GtfsProperty("service_id", 0)]
        public string ServiceId { get; set; }

        [GtfsProperty("date", 1)]
        public string Date { get; set; }

        [GtfsProperty("exception_type", 2)]
        public ExceptionType ExceptionType { get; set; }
    }
}
