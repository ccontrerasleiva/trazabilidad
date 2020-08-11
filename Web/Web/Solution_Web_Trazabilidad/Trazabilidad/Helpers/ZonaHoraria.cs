namespace Helpers
{
    using System;

    public class ZonaHoraria
    {

        public static DateTime GetHoraZonaHorariaPacific()
        {
            DateTime dt = new DateTime();
            var info = TimeZoneInfo.FindSystemTimeZoneById("Pacific SA Standard Time");
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(localServerTime, info);

            return dt = localTime.DateTime;
        }

    }
}