using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using World.Models;
using WorldLib.DAL;
using WorldLib.Models;

namespace World.Controllers
{
    public class CityController : Controller
    {

        /**** DEPENDENCY INJECTION *****/
        private ICityDAO cityDAO;
        private ICountryDAO countryDAO;

        public CityController(ICityDAO cityDAO, ICountryDAO countryDAO)
        {
            this.cityDAO = cityDAO;
            this.countryDAO = countryDAO;
        }

        public IActionResult Index()
        {
            IList<City> cities = cityDAO.GetCities();
            return View(cities);
        }

        public IActionResult Search(CitySearchVM vm)
        {
            // NOTE we are setting a Message if there is no search criteria
            if (vm.CountryCode == null && vm.District == null)
            {
                ViewData["Message"] = "Enter search criteria";
                vm.Cities = new List<City>();
            }
            else
            {
                vm.Cities = cityDAO.GetCities(vm.CountryCode, vm.District);
            }

            // Populate the country list on the view model
            // Call GetCountries() on the countryDAO.
            IList<Country> countries = countryDAO.GetCountries();
            vm.CountryList = new SelectList(countries, "Code", "Name");

            return View(vm);
        }

        // Implement the PRG pattern to ADD a city
        // Add (GET) action to show the form
        [HttpGet]
        public IActionResult Add()
        {
            City city = new City();
            return View(city);
        }

        // Create an Add (POST) method to get the form data and call the dao to add a city
        [HttpPost]
        // Add (GET) action to show the form
        public IActionResult Add(City city)
        {
            // Check model state before updating. If there are errors, return the form to the user.
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            int newCityId = cityDAO.AddCity(city);

            // Add a confirmation message to the user and then re-direct to the search page
            TempData["Message"] = $"City '{city.Name}' was added with id {newCityId}";

            // Redirect to the search page
            CitySearchVM vm = new CitySearchVM()
            {
                CountryCode = city.CountryCode,
                District = city.District
            };
            return RedirectToAction("Search", vm);
        }

        // ConfirmAdd (GET) method to read the added city and call the view
        [HttpGet]
        public IActionResult ConfirmAdd(int id)
        {
            City city = cityDAO.GetCityById(id);
            return View(city);
        }

        // Detail (GET) method to handle the request and show the form
        [HttpGet]
        public IActionResult Detail(int id)
        {
            City city = cityDAO.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }


        // Implement the PRG pattern to DELETE a city
        // Delete (GET) method to handle the request and show the form and ask the user to confirm
        [HttpGet]
        public IActionResult Delete(int id)
        {
            City city = cityDAO.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // Delete (POST) method to call the dao to delete a city
        [HttpPost]
        public IActionResult Delete(City city)
        {
            cityDAO.DeleteCity(city.CityId);
            return RedirectToAction("ConfirmDelete");
        }

        // ConfirmDelete (GET) method call the view to confirm
        [HttpGet]
        public IActionResult ConfirmDelete()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // Find the city to update
            City city = cityDAO.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }

            // Show the form
            return View(city);
        }

        public IActionResult Update(City city)
        {
            // Check model state before updating. If there are errors, return the form to the user.
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            cityDAO.UpdateCity(city);

            // Add a confirmation message to the user and then re-direct to the search page
            TempData["Message"] = $"City '{city.Name}' was updated";

            // Redirect to the Update (GET) page, to re-display the city
            return RedirectToAction("Update", new { id = city.CityId });
        }
    }
}