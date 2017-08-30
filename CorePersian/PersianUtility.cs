using CoreUtilities;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CorePersian
{
    internal static class PersianUtility
    {
        public static PersianDateTime GetRandomPersianDateTime(PersianDateTime startDataTime = null, PersianDateTime endDataTime = null)
        {
            var start = startDataTime?.ToDateTime() ?? DateTime.Now.AddYears(-20);
            var end = endDataTime?.ToDateTime() ?? new PersianDateTime(DateTime.Now).ToDateTime();
            var dt = RandomUtility.GetRandomDateTime(start, end);
            return new PersianDateTime(dt);
        }

        internal static bool IsValidNationalCode(string nationalCode)
        {
            //در صورتی که کد ملی وارد شده تهی باشد

            if (string.IsNullOrEmpty(nationalCode))
                throw new Exception("لطفا کد ملی را صحیح وارد نمایید");


            //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
            if (nationalCode.Length != 10)
                throw new Exception("طول کد ملی باید ده کاراکتر باشد");

            //در صورتی که کد ملی ده رقم عددی نباشد
            var regex = new Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
                throw new Exception("کد ملی تشکیل شده از ده رقم عددی می‌باشد؛ لطفا کد ملی را صحیح وارد نمایید");

            //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
            var allDigitEqual = new[]
            {
                "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666",
                "7777777777", "8888888888", "9999999999"
            };
            if (allDigitEqual.Contains(nationalCode)) return false;


            //عملیات شرح داده شده در بالا
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = num0 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
            var c = b % 11;

            return ((c < 2) && (a == c)) || ((c >= 2) && (11 - c == a));
        }

        internal static string RemoveArabicLetters(string value)
        {
            return value.Replace("ك", "ک").Replace("ي", "ی").Replace("ة", "ه");
        }

        internal static string RemoveDiacritics(string value)
        {
            var normalizedString = value.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
                else
                //اسامی مانند آفتاب نباید خراب شوند
                    if (c == 1619) //آ
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        internal static string ToEnglishNumbers(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return
                input
                    .Replace("\u0660", "0") //٠
                    .Replace("\u06F0", "0") //۰
                    .Replace("\u0661", "1") //١
                    .Replace("\u06F1", "1") //۱
                    .Replace("\u0662", "2") //٢
                    .Replace("\u06F2", "2") //۲
                    .Replace("\u0663", "3") //٣
                    .Replace("\u06F3", "3") //۳
                    .Replace("\u0664", "4") //٤
                    .Replace("\u06F4", "4") //۴
                    .Replace("\u0665", "5") //٥
                    .Replace("\u06F5", "5") //۵
                    .Replace("\u0666", "6") //٦
                    .Replace("\u06F6", "6") //۶
                    .Replace("\u0667", "7") //٧
                    .Replace("\u06F7", "7") //۷
                    .Replace("\u0668", "8") //٨
                    .Replace("\u06F8", "8") //۸
                    .Replace("\u0669", "9") //٩
                    .Replace("\u06F9", "9") //۹
                ;
        }

        internal static string ToPersianNumbers(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            input = PersianUtility.ToEnglishNumbers(input);
            return
                input
                    .Replace("0", "\u06F0")
                    .Replace("1", "\u06F1")
                    .Replace("2", "\u06F2")
                    .Replace("3", "\u06F3")
                    .Replace("4", "\u06F4")
                    .Replace("5", "\u06F5")
                    .Replace("6", "\u06F6")
                    .Replace("7", "\u06F7")
                    .Replace("8", "\u06F8")
                    .Replace("9", "\u06F9")
                ;
        }
    }
}
