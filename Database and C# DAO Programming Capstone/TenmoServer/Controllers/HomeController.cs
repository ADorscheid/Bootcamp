using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public object Home()
        {
            object sampleData = new
            {
                title = "Welcome to Tenmo!",
                message = "Please login"
            };
            return Ok(sampleData);
        }
    }
}
