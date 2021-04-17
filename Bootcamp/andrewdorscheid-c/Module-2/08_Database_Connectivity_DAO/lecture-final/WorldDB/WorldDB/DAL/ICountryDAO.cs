using System.Collections.Generic;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public interface ICountryDAO
    {
        IList<Country> GetCountries();
        List<Country> GetCountries(string continent);
        Country GetCountry(string code);
    }
}