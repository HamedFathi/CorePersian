using System.Collections.Generic;

namespace CorePersian
{
    public class Province
    {
        public string Capital { get; set; }

        public List<string> Cities { get; set; }

        public string Name { get; set; }

        public Province()
        {
            Cities = new List<string>();
        }
    }
}
