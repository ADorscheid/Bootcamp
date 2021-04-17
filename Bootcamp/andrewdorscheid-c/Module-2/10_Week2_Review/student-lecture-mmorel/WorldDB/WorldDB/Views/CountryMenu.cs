using WorldDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorldDB.DAL;
using MenuFramework;

namespace WorldDB.Views
{
    /// <summary>
    /// The Country sub-menu
    /// </summary>
    public class CountryMenu : ConsoleMenu
    {
        private Country country = null;

        // Store the Interfaces to our data objects
        private ICityDAO cityDAO;
        private ICountryLanguageDAO countryLanguageDAO;
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public CountryMenu(Country country, ICityDAO cityDAO, ICountryLanguageDAO countryLanguageDAO)
        {
            // Update this constructor to accept appropriate daos, and save them in local variables.
            this.cityDAO = cityDAO;
            this.countryLanguageDAO = countryLanguageDAO;

            // Save the country (which will be used for all country queries
            this.country = country;

            // This code is just protection because before we complete the code, Country may be null
            if (country == null)
            {
                country = new Country();
            }

            // Add options to this menu
            AddOption($"List Cities in {country.Name}", ListCities)
                .AddOption($"List Languages in {country.Name}", ListLanguages)
                .AddOption($"Add a city to {country.Name}", AddCity)
                .AddOption("Remove a city", RemoveCity)
                .AddOption("Back", Exit);

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.DarkGreen;
                cfg.SelectedItemForegroundColor = ConsoleColor.Green;
            });

        }

        private MenuOptionResult RemoveCity()
        {
            // Prompt the user for a city name
            string cityName = GetString("Enter the name of the city to remove: ");

            // Call the DAO to Delete a city by name
            int rowsDeleted = cityDAO.DeleteCity(cityName, country.Code);

            if (rowsDeleted == 0)
            {
                Console.WriteLine($"City {cityName}, {country.Code} was not found, and therefore not deleted.");
            }
            else
            {
                Console.WriteLine($"City {cityName}, {country.Code} was deleted.");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ListLanguages()
        {
            // TODO 16: Get the list of languages for this country (GetLanguages)
            IList<CountryLanguage> languages = countryLanguageDAO.GetLanguages(this.country.Code);
            SetColor(ConsoleColor.Blue);
            Console.WriteLine(CountryLanguage.GetHeader());
            foreach (CountryLanguage language in languages)
            {
                Console.WriteLine(language);
            }
            ResetColor();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ListCities()
        {
            // Get the list of cities (GetCitiesByCountryCode)
            IList<City> cities = cityDAO.GetCitiesByCountry(country.Code);

            SetColor(ConsoleColor.DarkYellow);
            Console.WriteLine(City.GetHeader());
            foreach (City city in cities)
            {
                Console.WriteLine(city);
            }
            ResetColor();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult AddCity()
        {
            SetColor(ConsoleColor.Cyan);
            string name = GetString("Name of the city: ");
            string district = GetString($"District {name} is in: ");
            int population = GetInteger($"Population of {name}: ");

            // Create a city object and set its properties
            City newCity = new City()
            {
                Name = name,
                CountryCode = country.Code,
                District = district,
                Population = population
            };

            // Add the city (AddCity)
            int newCityId = cityDAO.AddCity(newCity);
            if (newCityId > 0)
            {
                Console.WriteLine($"City was added with id {newCityId}.");
            }
            else
            {
                Console.WriteLine("City was not added");
            }
            ResetColor();
            return MenuOptionResult.WaitAfterMenuSelection;
        }


        protected override void OnBeforeShow()
        {
            SetColor(ConsoleColor.Magenta);

            // TODO 11: Print a header that shows Country information
            Console.WriteLine(new string('=', 70));
            Console.WriteLine($"{country.Name,-39} Population: {country.Population:N0}");
            Console.WriteLine(new string('=', 70));
            Console.WriteLine();

            ResetColor();
        }

    }
}
