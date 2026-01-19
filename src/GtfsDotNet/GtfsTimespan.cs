using System;
using System.Collections.Generic;
using System.Text;

namespace GtfsDotNet
{
    internal static class GtfsTimespan
    {
        internal static TimeSpan? ParseGtfsTimespan(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            var values = s.Split(':');
            if (values.Length != 3)
                return null;

            if (!int.TryParse(values[0], out var hours) ||
                !int.TryParse(values[1], out var minutes) ||
                !int.TryParse(values[2], out var seconds) ||
                hours < 0 ||
                minutes < 0 || minutes > 59 ||
                seconds < 0 || seconds > 59)
                return null;

            return new TimeSpan(hours, minutes, seconds);
        }
    }
}
