using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;
using TenmoServer.DAO;
using Microsoft.AspNetCore.Authorization;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TransfersController : ControllerBase
    {
        private ITransferDAO TransferDAO;
        private IAccountDAO AccountDAO;

        public TransfersController (ITransferDAO transferDAO, IAccountDAO accountDAO)
        {
            this.TransferDAO = transferDAO;
            this.AccountDAO = accountDAO;
        }

        // called by ViewTransfers in the main menu
        // returns a list of all transfers of the user
        [HttpGet]
        public List<Transfer> GetTransfers()
        {
            List<Transfer> transfers = TransferDAO.GetTransfers(User.Identity.Name);
           
            return transfers;
        }

        // creates a transfer for the user
        // gets the balances of both accounts, and does a transfer.  if the transfer is sucessful, it'll the url with the new transfer id
        [HttpPost]
        public ActionResult<Transfer> CreateTransfer(Transfer newTransfer)
        {
            Transfer transfer = TransferDAO.CreateTransfer(newTransfer);
            decimal fromAccountBalance = AccountDAO.GetBalance(newTransfer.AccountFrom);
            decimal toAccountBalance = AccountDAO.GetBalance(newTransfer.AccountTo);
            bool transferSuccessful = AccountDAO.SendMoney(transfer, fromAccountBalance, toAccountBalance);
            return Created($"/transfers/{transfer.TransferId}", transfer);
        }

        //Transfers/{id}
    }
}
