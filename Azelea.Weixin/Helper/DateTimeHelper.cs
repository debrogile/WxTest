using System;

namespace Azelea.Weixin
{
    public static class DateTimeHelper
    {
        private static DateTime BaseTime = new DateTime(1970, 1, 1);

        public static DateTime GetDateTimeFromXml(string dateTimeFromXml)
        {
            long seconds = long.Parse(dateTimeFromXml);

            return BaseTime.ToLocalTime().AddSeconds(seconds);
        }

        public static long GetWeixinDateTime(this DateTime dt)
        {
            return (dt.ToUniversalTime().Ticks - BaseTime.Ticks) / 10000000;
        }
    }
}
