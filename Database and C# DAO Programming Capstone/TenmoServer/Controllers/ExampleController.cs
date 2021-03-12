using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Controllers
{
    [Route("/")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public object Home()
        {
            object sampleData = new { title = "Welcome to TEnmo!", message = "Please login for further functionality" };
            return Ok(sampleData);
        }
    }
}
