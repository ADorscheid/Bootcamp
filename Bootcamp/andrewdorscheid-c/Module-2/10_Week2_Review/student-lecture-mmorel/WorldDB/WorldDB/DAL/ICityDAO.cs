using System.Collections.Generic;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public interface ICityDAO
    {
        int AddCity(City cityToAdd);
        int DeleteCity(string cityName, string countryCode);
        List<City> GetCitiesByCountry(string countryCode);
    }
}