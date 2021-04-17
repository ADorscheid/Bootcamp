using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDB.Models
{
    public class CountryLanguage
    {
        public string CountryCode { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public bool IsOfficial { get; set; }
        public float Percentage { get; set; }


        // **************************************************************
        // ToString and GetHeader for Language
        // **************************************************************
        public override string ToString()
        {
            return $"{CountryCode,-4} {LanguageName,-30} {(IsOfficial ? "Official" : "Unofficial"),11} {(Percentage / 100.00),7:P} ";
        }
        public static string GetHeader()
        {
            return $@"{"Code",-4} {"Name",-30} {"Official",11} {"%",7}
{"----",-4} {"----",-30} {"--------",11} {"------",7}";
        }
    }
}
