using CoreExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CorePersian
{
    public static class TestDataUtility
    {
        public static List<Province> GetIranProvinces()
        {
            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("CorePersian.TestData.IranProvinces").ToString();
            return JsonConvert.DeserializeObject<List<Province>>(resource);
        }

        public static PersianNames GetPersianNames()
        {
            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("CorePersian.TestData.PersianNames").ToString();
            return JsonConvert.DeserializeObject<PersianNames>(resource);
        }
    }
}
