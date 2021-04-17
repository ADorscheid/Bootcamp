using System;
using System.Collections.Generic;
using System.Text;

namespace API_Get
{
    public class Exchange
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public int TimeLastUpdated { get; set; }

        public DateTime LastUpdated
        {
            get
            {
                // TimeLastUpdated is a Unix time...convert to DateTime
                return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(TimeLastUpdated);
            }
        }
        public Dictionary<string, double> Rates{ get; set; }
    }
}
