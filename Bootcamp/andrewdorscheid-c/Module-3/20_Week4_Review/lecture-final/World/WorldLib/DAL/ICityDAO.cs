using System.Collections.Generic;
using WorldLib.Models;

namespace WorldLib.DAL
{
    public interface ICityDAO
    {
        City GetCityById(int id);
        IList<City> GetCities();
        IList<City> GetCities(string countryCode, string district);
        int AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int cityId);
    }
}
