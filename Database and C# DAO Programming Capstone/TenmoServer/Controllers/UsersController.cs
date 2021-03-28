using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserDAO UserDAO;

        public UsersController(IUserDAO userDAO)
        {
            this.UserDAO = userDAO;
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return Ok(UserDAO.GetUsers());
        }
    }
}
