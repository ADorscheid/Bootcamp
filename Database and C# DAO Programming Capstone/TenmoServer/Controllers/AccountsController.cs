﻿using Microsoft.AspNetCore.Authorization;
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
    public class AccountsController : ControllerBase
    {
        private IAccountDAO AccountDAO;

        public AccountsController(IAccountDAO accountDAO)
        {
            this.AccountDAO = accountDAO;
        }

        //accounts
        [HttpGet]
        public ActionResult<List<Account>> GetAccounts()
        {
            List<Account> accounts = AccountDAO.GetAccounts(User.Identity.Name);
            if (accounts == null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }

        //accounts/accountId
        // used for displaying account balance in main menu
        [HttpGet("{accountId}")]
        public ActionResult<Account> GetAccount(int accountId)
        {
            Account account = null;
            account = AccountDAO.GetAccount(User.Identity.Name, accountId);
            
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}
