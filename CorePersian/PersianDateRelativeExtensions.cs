using System;
using System.Collections.Generic;
using System.Text;

namespace CorePersian
{
    public static class PersianDateRelativeExtensions
    {
        internal static class PersianMessages
        {
            public const string DaysAgo = "{0} روز قبل";
            public const string EmailTaken = "آدرس ایمیل وارد شده قبلا ثبت شده است";
            public const string FailedLogin = "نام کاربری و/یا کلمه عبور اشتباه است";
            public const string HoursAgo = "{0} ساعت قبل";
            public const string JustNow = "همین الان";
            public const string LastMonth = "ماه قبل";
            public const string LastWeek = "هفته قبل";
            public const string LastYear = "سال قبل";
            public const string MinutesAgo = "{0} دقیقه قبل";
            public const string MonthsAgo = "{0} ماه قبل";
            public const string NotYet = "هنوز نه";
            public const string NoValue = "موجود نیست";
            public const string SignedupSuccessfully = "ثبت نام انجام شد؛ پیشنهاد می کنیم پست الکترونیکی خود را تایید کنید، اطلاعات مورد نیاز برایتان ارسال شده است";
            public const string ThreeWeeksAgo = "سه هفته قبل";
            public const string TwoWeeksAgo = "دو هفته قبل";
            public const string UsernameTaken = "نام کاربری وارد شده موجود نیست";
            public const string YearsAgo = "{0} سال قبل";
            public const string Yesterday = "دیروز";
        }

        public static string PersianRelativeDate(this System.DateTime date)
        {
            var timeSince = System.DateTime.Now.Subtract(date);
            if (timeSince.TotalMilliseconds < 1) return PersianMessages.NotYet;
            if (timeSince.TotalMinutes < 1) return PersianMessages.JustNow;
            if (timeSince.TotalMinutes < 60) return string.Format(PersianMessages.MinutesAgo, timeSince.Minutes);
            if (timeSince.TotalHours < 24) return string.Format(PersianMessages.HoursAgo, timeSince.Hours);
            if (timeSince.TotalDays < 2) return PersianMessages.Yesterday;
            if (timeSince.TotalDays < 7) return string.Format(PersianMessages.DaysAgo, timeSince.Days);
            if (timeSince.TotalDays < 14) return PersianMessages.LastWeek;
            if (timeSince.TotalDays < 21) return PersianMessages.TwoWeeksAgo;
            if (timeSince.TotalDays < 28) return PersianMessages.ThreeWeeksAgo;
            if (timeSince.TotalDays < 60) return PersianMessages.LastMonth;
            if (timeSince.TotalDays < 365) return string.Format(PersianMessages.MonthsAgo, Math.Round(timeSince.TotalDays / 30));
            return timeSince.TotalDays < 730
                ? PersianMessages.LastYear
                : string.Format(PersianMessages.YearsAgo, Math.Round(timeSince.TotalDays / 365));
        }

        public static string PersianRelativeDate(this PersianDateTime date)
        {
            var gDate = date.ToDateTime();
            return gDate.PersianRelativeDate();
        }
    }
}
