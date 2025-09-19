using GtfsDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtfsDotNet.Model
{
    [GtfsFile("agency.txt")]
    public class Agency : GtfsDataItem
    {
        [GtfsProperty("agency_id", 0)]
        public string AgencyId { get; set; }

        [GtfsProperty("agency_name", 1)]
        public string AgencyName { get; set; }

        [GtfsProperty("agency_url", 2)]
        public string AgencyUrl { get; set; }

        [GtfsProperty("agency_timezone", 3)]
        public string AgencyTimezone { get; set; }

        [GtfsProperty("agency_lang", 4)]
        public string AgencyLanguage { get; set; }

        [GtfsProperty("agency_phone", 5)]
        public string AgencyPhone { get; set; }

        [GtfsProperty("agency_fare_url", 6)]
        public string AgencyFareUrl { get; set; }

        [GtfsProperty("agency_email", 7)]
        public string AgencyEmail { get; set; }
    }
}
