using CoreExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CorePersian
{
    public enum Continent
    {
        [Description("آفریقا")]
        Africa,

        [Description("قطب جنوب")]
        Antarctica,

        [Description("آسیا")]
        Asia,

        [Description("استرالیا")]
        Australia,

        [Description("اروپا")]
        Europe,

        [Description("آمریکا شمالی")]
        NorthAmerica,

        [Description("آمریکا جنوبی")]
        SouthAmerica
    }

    public class PersianCountry
    {
        public int AreaCode { get; set; }

        public string LatinCapitalName { get; set; }

        public Continent LatinContinentName { get; set; }

        public string LatinCurrencyName { get; set; }

        public string LatinName { get; set; }

        public string PersianCapitalName { get; set; }

        public string PersianContinentName
        {
            get
            {
                return LatinContinentName.GetDescription();
            }
        }

        public string PersianCurrencyName { get; set; }

        public string PersianName { get; set; }
    }
}
