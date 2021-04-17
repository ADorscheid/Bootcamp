using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Controllers
{
    [Route("people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // Pretend we have a dao
        private static List<Person> people = new List<Person>()
        {
            new Person(1, "Mike", 71),
            new Person(2, "Kareem", 86),
            new Person(3, "JD", 72),
            new Person(4, "Janitor", 77)
        };

        [HttpGet]
        public List<Person> ThisCanBeAnyNameWhatsoever()
        {
            // Execute a DAO.GetPeople here...
            return people;
        }

        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            Person person = people.Find( p => p.Id == id);
            return person;
        }
    }
}
