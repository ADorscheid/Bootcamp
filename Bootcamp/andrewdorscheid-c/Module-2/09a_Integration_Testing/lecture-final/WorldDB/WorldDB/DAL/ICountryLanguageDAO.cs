using System.Collections.Generic;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public interface ICountryLanguageDAO
    {
        List<CountryLanguage> GetLanguages(string countryCode);
    }
}