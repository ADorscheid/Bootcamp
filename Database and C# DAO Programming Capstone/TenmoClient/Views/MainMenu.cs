using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.DAL;
using TenmoClient.Data;

namespace TenmoClient.Views
{
    public class MainMenu : ConsoleMenu
    {
        private IAccountDAO accountDao;
        private ITransferDAO transferDao;
        private IUserApiDAO userDao;

        public MainMenu(string api_url)
        {
            this.accountDao = new AccountApiDAO(api_url);
            this.transferDao = new TransferApiDAO(api_url);
            this.userDao = new UserApiDAO(api_url);

            AddOption("View your current balance", ViewBalance)
                .AddOption("View your past transfers", ViewTransfers)
                .AddOption("Send TE bucks", SendTEBucks)
                .AddOption("Log in as different user", Logout)
                .AddOption("Exit", Exit);
        }

        protected override void OnBeforeShow()
        {
            Console.WriteLine($"TE Account Menu for User: {UserService.GetUserName()}");
        }

        private MenuOptionResult ViewBalance()
        {
            try
            {
                int accountId = MainMenu.GetInteger("Please enter your account Id: ");

                Account account = accountDao.GetAccount(accountId);
                Console.WriteLine($"Your account {accountId} has the balance of: {account.Balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ViewTransfers()
        {
            try
            {
                string toUsername = "";
                string fromUsername = "";
                string type = "";

                List<Transfer> transfers = transferDao.GetTransfers(UserService.GetUserName());
                List<API_User> users = userDao.GetUsers();

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Transfers");
                Console.WriteLine($"{"ID",-5}          {"From/To",-20}                 {"Amount",-10}");
                Console.WriteLine("--------------------------------------------------------------");

                // loop through users and transfers and display all transfers that this user is authorized to
                // it'll display in order of transfer id
                foreach (Transfer transfer in transfers)
                {
                        foreach (API_User user in users)
                        {
                        if (user.UserId == transfer.AccountTo && user.Username != UserService.GetUserName())
                        {
                            type = ($"Type: Send");
                            fromUsername = UserService.GetUserName();
                            toUsername =  user.Username;

                            Console.WriteLine($"{transfer.TransferId,-5}            {$"To: {toUsername}",-20}              {transfer.Amount,-10}");
                        }
                        if (user.UserId == transfer.AccountFrom && user.Username != UserService.GetUserName())
                        {
                            type = ($"Type: Receive");
                            fromUsername = user.Username;
                            toUsername = UserService.GetUserName();
                            
                            Console.WriteLine($"{transfer.TransferId,-5}            {$"From: {fromUsername}",-20}              {transfer.Amount,-10}");
                        }
                    }

                }

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("");
                bool badInput = true;
                int transferId = -1;

                //loop until we find a valid transfer ID
                while (badInput)
                {

                    transferId = GetInteger("Enter Transfer ID to view (0 to cancel): ");
                    if (transferId == 0)
                    {
                        return MenuOptionResult.WaitAfterMenuSelection;
                    }
                    foreach (Transfer transfer in transfers)
                    {
                        if (transfer.TransferId == transferId)
                        {
                            Console.Clear();
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine("Transfer Details");
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine($"Id: {transfer.TransferId}");
                            Console.WriteLine($"From: {fromUsername}");
                            Console.WriteLine($"To: {toUsername}");
                            Console.WriteLine($"{type}");
                            Console.WriteLine($"Status: Approved");
                            Console.WriteLine($"Amount: {transfer.Amount:C2}");
                            badInput = false;
                        }
                    }
                    if (badInput)
                    {
                        Console.WriteLine("Please enter a valid transfer ID!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult SendTEBucks()
        {
            try
            {
                List<API_User> users = userDao.GetUsers();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Users");
                Console.WriteLine("ID                           Name");
                Console.WriteLine("-------------------------------------------");
                foreach (API_User user in users)
                {
                    Console.WriteLine($"{user.UserId}                           {user.Username}");
                }
                Console.WriteLine("---------");
                Console.WriteLine("");


                bool badInput = true;
                int toUserId = -1;
                //loop until we find a user id that is actually in the list
                while (badInput)
                {
                    toUserId = GetInteger("Enter ID of user you are sending to (0 to cancel): ");
                    if (toUserId == 0)
                    {
                        return MenuOptionResult.WaitAfterMenuSelection;
                    }
                    foreach (API_User user in users)
                    {
                        if (user.UserId == toUserId && toUserId != UserService.GetUserId())
                        {
                            badInput = false;
                        }
                    }
                    if (badInput)
                    {
                        Console.WriteLine("Please enter a valid User Id");
                    }
                }

                // make sure amount is greater than 0
                badInput = true;
                decimal amount = -1;
                while (badInput)
                {
                    amount = GetInteger("Enter amount: ");
                    if (amount <= 0)
                    {
                        Console.WriteLine("Please enter an amount greater than 0");
                    }
                    else
                    {
                        badInput = false;
                    }
                }

                // check to make sure your balance has enough money in it to transfer to the other account
                Account fromAccount = accountDao.GetAccount(UserService.GetUserId());
                if (amount > fromAccount.Balance)
                {
                    Console.WriteLine("Insufficient balance");
                    return MenuOptionResult.WaitAfterMenuSelection;
                }
                else
                {
                    bool transferSuccessful = transferDao.SendMoney(fromAccount.AccountId, toUserId, amount);
                    if (transferSuccessful)
                    {
                        Console.WriteLine("TRANSACTION APPROVED!");
                    }
                    else
                    {
                        Console.WriteLine("TRANSACTION FAILED");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult Logout()
        {
            UserService.SetLogin(new API_User()); //wipe out previous login info
            return MenuOptionResult.CloseMenuAfterSelection;
        }

    }
}
