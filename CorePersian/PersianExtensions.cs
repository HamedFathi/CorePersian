using System;

namespace CorePersian
{
    public static class PersianExtensions
    {
        public static bool IsValidNationalCode(this string nationalCode)
        {
            return PersianUtility.IsValidNationalCode(nationalCode);

        }

        public static string RemoveArabicLetters(this string value)
        {
            return PersianUtility.RemoveArabicLetters(value);
        }

        public static string RemoveArabicLetters(this char value)
        {
            return PersianUtility.RemoveArabicLetters(value.ToString());
        }

        public static string RemoveDiacritics(this string value)
        {
            return PersianUtility.RemoveDiacritics(value);
        }

        public static string RemoveDiacritics(this char value)
        {
            return PersianUtility.RemoveDiacritics(value.ToString());
        }

        public static string ToEnglishNumbers(this string input)
        {
            return PersianUtility.ToEnglishNumbers(input);
        }

        public static char ToEnglishNumbers(this char input)
        {
            return Convert.ToChar(PersianUtility.ToEnglishNumbers(input.ToString()));
        }

        public static string ToPersianNumbers(this string input)
        {
            return PersianUtility.ToPersianNumbers(input);
        }

        public static char ToPersianNumbers(this char input)
        {
            return Convert.ToChar(PersianUtility.ToPersianNumbers(input.ToString()));
        }
    }
}
