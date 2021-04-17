using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDB.Models
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public double SurfaceArea { get; set; }
        public int Population { get; set; }

        // **************************************************************
        // ToString and GetHeader for Country
        // **************************************************************
        public override string ToString()
        {
            return $"{Code,-4} {Name,-40} {Continent,-30}";
            //return Code.PadRight(5) + Name.PadRight(20) + Continent.PadRight(30) + SurfaceArea.ToString("N2").PadRight(10) + Population.ToString("N0").PadRight(15) + GovernmentForm.PadRight(30);
        }
        public static string GetHeader()
        {
            return $@"{"Code",-4} {"Name",-40} {"Continent",-30}
{"----",-4} {"----",-40} {"---------",-30}";

        }

    }
}
