using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Locations.DAO;
using Locations.Models;

namespace Locations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationDao dao;

        public LocationsController(ILocationDao locationsDao)
        {
            dao = locationsDao;
        }

        [HttpGet]
        public List<Location> List()
        {
            return dao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Location> Get(int id)
        {
            Location location = dao.Get(id);
            if (location != null)
            {
                return Ok(location);
            }
            else
            {
                return NotFound("Location does not exist");
            }
        }

        [HttpPost]
        public ActionResult<Location> Add(Location location)
        {
            Location returnLocation = dao.Create(location);
            return Created($"/locations/{returnLocation.Id}", returnLocation);
        }

        [HttpPut("{id}")]
        public ActionResult<Location> Update(int id, Location location)
        {
            Location existingLocation = dao.Get(id);
            if (existingLocation == null)
            {
                return NotFound("Location does not exist");
            }

            Location result = dao.Update(id, location);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Location location = dao.Get(id);
            if (location == null)
            {
                return NotFound("Location does not exist");
            }

            dao.Delete(id);
            return NoContent();
        }


    }
}
