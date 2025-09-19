using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    [GtfsFile("fare_media.txt")]
    public class FareMedia : GtfsDataItem
    {
        [GtfsProperty("fare_media_id", 0)]
        public string FareMediaId { get; set; }

        [GtfsProperty("fare_media_name", 1)]
        public string FareMediaName { get; set; }

        [GtfsProperty("fare_media_desc", 2)]
        public string FareMediaDesc { get; set; }
    }

}
