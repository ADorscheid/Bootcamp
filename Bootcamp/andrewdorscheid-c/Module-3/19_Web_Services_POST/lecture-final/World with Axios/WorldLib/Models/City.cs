using System;
using System.ComponentModel.DataAnnotations;

namespace WorldLib.Models
{
    public class City
    {
        /// <summary>
        /// Unique identifier for the city.
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Name of the city.
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [StringLength(64)]
        public string Name { get; set; }
        
        /// <summary>
        /// 3-character ISO country code to which the city belongs.
        /// </summary>
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Country Code must be exactly 3  characters.")]
        [Display(Name = "Country Code", Prompt = "e.g., \"USA\"")]
        public string CountryCode { get; set; }
        
        /// <summary>
        /// Name of the country to which the city belongs.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// State of Province to which the city belongs.
        /// </summary>
        [Required]
        public string District { get; set; }

        /// <summary>
        /// Number of people the city contains.
        /// </summary>
        [Range(1, 99999999)]
        public int Population { get; set; }

        public City() { }

        public City(int cityId, String name, string countryCode, string countryName, string district, int population)
        {
            CityId = cityId;
            Name = name;
            CountryCode = countryCode;
            CountryName = countryName;
            District = district;
            Population = population;
        }
    }
}
