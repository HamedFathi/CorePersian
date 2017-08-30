using System;
using System.Collections.Generic;
using System.Text;

namespace CorePersian
{
    public class PersianNames
    {
        public List<string> BoysFirstName { get; set; }

        public List<string> GirlsFirstName { get; set; }

        public List<string> LastNames { get; set; }

        public PersianNames()
        {
            BoysFirstName = new List<string>();
            GirlsFirstName = new List<string>();
            LastNames = new List<string>();
        }
    }
}
