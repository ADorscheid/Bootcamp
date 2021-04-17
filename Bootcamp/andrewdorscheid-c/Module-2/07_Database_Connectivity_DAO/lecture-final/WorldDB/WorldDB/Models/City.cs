using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDB.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string CountryCode { get; set; }
        public int Population { get; set; }

        public override string ToString()
        {
            return $"{CityId,5} {Name,-30} {District,-30} {Population,10:N0}";
        }

        public static string GetHeader()
        {
            return $@"{"Id",5} {"Name",-30} {"District",-30} {"Population",10}
{"--",5} {"----",-30} {"--------",-30} {"----------",10}";
        }
    }
}
