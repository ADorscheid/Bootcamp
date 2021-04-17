using System.Collections.Generic;
using WorldLib.Models;

namespace WorldLib.DAL
{
    public interface ICountryDAO
    {
        IList<Country> GetCountries();
        IList<Country> GetCountries(string continent);
        int AddCountry(Country country);
    }
}
