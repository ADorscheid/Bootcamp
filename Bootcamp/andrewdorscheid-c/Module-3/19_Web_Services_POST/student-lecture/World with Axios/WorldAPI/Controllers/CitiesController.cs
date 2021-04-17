using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorldLib.DAL;
using WorldLib.Models;

namespace WorldAPI.Controllers
{
    // TODO 03 (Controller): Add CitiesController as an APiController
    // TODO 05 (COntroller): Add the default route to this controller (api/cities)
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        /**** DEPENDENCY INJECTION *****/
        private ICityDAO cityDAO;

        private readonly ILogger<CitiesController> _logger;

        // TODO 04 (Controller): implement dependency injection to get CityDAO
        public CitiesController(ILogger<CitiesController> logger, ICityDAO cityDAO)
        {
            _logger = logger;
            this.cityDAO = cityDAO;
        }

        // TODO 06 (Controller): Add GET api/cities to get all cities
        // TODO 07 (Controller): Modify GET api/cities to take search parameters
        /// <summary>
        /// Get a list of cities of the world. 
        /// </summary>
        /// <param name="countryCode">3-character ISO country code</param>
        /// <param name="district">State or province in the specified country</param>
        /// <returns>If countryCode and district are both NULL, returns all cities in the DB. Otherwise filters the
        /// results by country and district.</returns>
        [HttpGet("")]
        public IActionResult GetCities(string countryCode, string district)
        {
            if (countryCode == null && district == null)
            {
                return new JsonResult(cityDAO.GetCities());
            }
            else
            {
                return new JsonResult(cityDAO.GetCities(countryCode, district));
            }
        }

        // TODO 08 (Controller): Add GET api/cities/{id} to get a single city

        /// <summary>
        /// Gets a single City by id.
        /// </summary>
        /// <param name="id">Identifier of the city</param>
        /// <returns>A City object. 404 if not found.</returns>
        /// <response code="200">City was not found and returned in body.</response>
        /// <response code="404">Id was not found</response>
        [HttpGet("{id}", Name = "GetCity")]
        [ProducesResponseType(404)]
        public IActionResult GetCity(int id)
        {
            City city = cityDAO.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            return new JsonResult(city);
        }

        // TODO 09 (Controller): Add POST api/cities to ADD a city
        /// <summary>
        /// Insert a City into the DB
        /// </summary>
        /// <param name="city">City object to add to the DB.</param>
        /// <returns>The new City object in the body, as well as a 201 Created message with a location to the new city.</returns>
        /// <response code="201">City was created.</response>
        /// <response code="400">Data was not valid for adding a city.</response>
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult AddCity([FromBody]City city)
        {
            if (ModelState.IsValid)
            {
                int newId = cityDAO.AddCity(city);
                city = cityDAO.GetCityById(newId);
                // TODO 09a (Controller): Return CreatedAtRoute to return 201
                return CreatedAtRoute("GetCity", new { id = newId }, city );
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        // TODO 10 (Controller): Add PUT api/cities/{id} to UPDATE a city
        /// <summary>
        /// Update an existing city
        /// </summary>
        /// <param name="city">City data to update. Id must exist in the db.</param>
        /// <returns>Ok</returns>
        /// <response code="200">City was updated.</response>
        /// <response code="400">Data was not valid for updating a city.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateCity(City city)
        {
            // Should I compare id to City.id?
            if (ModelState.IsValid)
            {
                cityDAO.UpdateCity(city);
                return Ok(city);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        // TODO 11 (Controller): Add DELETE api/cities/{id} to DELETE a city
        /// <summary>
        /// Remove a city from the db.
        /// </summary>
        /// <param name="id">Id of the city to remove</param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            cityDAO.DeleteCity(id);
            return Ok();
        }
    }
}
