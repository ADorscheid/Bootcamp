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
        public ActionResult<List<Transfer>> GetTransfers()
        {
            List<Transfer> transfers = TransferDAO.GetTransfers(User.Identity.Name);

            return Ok(transfers);
        }

        // creates a transfer for the user
        [HttpPost]
        public ActionResult<Transfer> CreateTransfer(Transfer newTransfer)
        {
            // get userId from the token
            int currentUserId = int.Parse(User.FindFirst("sub").Value);
            if (newTransfer.AccountFrom==currentUserId || (newTransfer.AccountTo==currentUserId && newTransfer.TransferTypeId==1))
            {
                Transfer transfer = TransferDAO.CreateTransfer(newTransfer);

                // if the transfer was a send and was auto accepted
                if (transfer.TransferTypeId == 2)
                {
                    //update balances
                    bool transferSuccessful = AccountDAO.SendMoney(transfer);
                }
                return Created($"/transfers/{transfer.TransferId}", transfer);
            }
            else
            {
                return Forbid();
            }
        }

        [HttpPut("{transfer.TransferId}")]
        public ActionResult<Transfer> UpdateTransfer(Transfer transfer)
        {
            // get userId from the token
            int currentUserId = int.Parse(User.FindFirst("sub").Value);
            if (transfer.AccountFrom == currentUserId)
            {
                TransferDAO.UpdateTransfer(transfer);
                if (transfer.TransferStatusId == 2)
                {
                    //update balances
                    bool transferSuccessful = AccountDAO.SendMoney(transfer);
                }
                return Ok();
            }
            else
            {
                return Forbid();
            }
        }
    }
}
