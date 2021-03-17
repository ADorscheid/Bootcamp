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

        public TransfersController(ITransferDAO transferDAO, IAccountDAO accountDAO)
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
        [HttpPost]
        public ActionResult<Transfer> CreateTransfer(Transfer newTransfer)
        {
            Transfer transfer = TransferDAO.CreateTransfer(newTransfer);
            // if the transfer was a send and was auto accepted
            if (transfer.TransferTypeId == 2)
            {
                //update balances
                decimal fromAccountBalance = AccountDAO.GetBalance(newTransfer.AccountFrom);
                decimal toAccountBalance = AccountDAO.GetBalance(newTransfer.AccountTo);
                bool transferSuccessful = AccountDAO.SendMoney(transfer, fromAccountBalance, toAccountBalance);
            }
            return Created($"/transfers/{transfer.TransferId}", transfer);
        }

        [HttpPut("{transfer.TransferId}")]
        public ActionResult<Transfer> UpdateTransfer(Transfer transfer)
        {
            TransferDAO.UpdateTransfer(transfer);
            if (transfer.TransferStatusId == 2)
            {
                decimal fromAccountBalance = AccountDAO.GetBalance(transfer.AccountFrom);
                decimal toAccountBalance = AccountDAO.GetBalance(transfer.AccountTo);
                bool transferSuccessful = AccountDAO.SendMoney(transfer, fromAccountBalance, toAccountBalance);
            }
            return Ok();
        }
    }
}
