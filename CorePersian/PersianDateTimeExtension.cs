using System;

namespace CorePersian
{
    public static class PersianDateTimeExtension
    {
        internal static string ToHHMM(this TimeSpan time)
        {
            return time.ToString("hh\\:mm");
        }

        internal static string ToHHMMSS(this TimeSpan time)
        {
            return time.ToString("hh\\:mm\\:ss");
        }

        internal static int ToInteger(this TimeSpan time)
        {
            return int.Parse(time.Hours.ToString() + time.Minutes.ToString().PadLeft(2, '0') + time.Seconds.ToString().PadLeft(2, '0'));
        }

        internal static short ToShort(this TimeSpan time)
        {
            return short.Parse(time.Hours.ToString() + time.Minutes.ToString().PadLeft(2, '0'));
        }
    }
}
