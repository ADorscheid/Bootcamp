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
        private IAccountDAO AccountDAO;
        private IUserDAO UserDAO;
        private ITransferDAO TransferDAO;

        public UsersController(IAccountDAO accountDAO, IUserDAO userDAO, ITransferDAO transferDAO)
        {
            this.AccountDAO = accountDAO;
            this.UserDAO = userDAO;
            this.TransferDAO = transferDAO;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return UserDAO.GetUsers();
        }
    }
}
