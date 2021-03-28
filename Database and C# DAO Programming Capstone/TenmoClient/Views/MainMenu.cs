using MenuFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .AddOption("View your approved transfers", ViewTransfers)
                .AddOption("Send TE bucks", SendTEBucks)
                .AddOption("Request TE bucks", RequestTEBucks)
                .AddOption("View pending transfers", ViewPendingTransfers)
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
                //int accountId = MainMenu.GetInteger("Please enter your account Id: ");

                Account account = accountDao.GetAccount(UserService.GetUserId());
                Console.WriteLine($"Your account {account.AccountId} has the balance of: {account.Balance:C2}");
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
                // in the future - change this to get Send transfers as the database / transfers grows
                List<Transfer> transfers = transferDao.GetTransfers().Where((transfer) =>
                {
                    // only interested in Send transfers
                    return transfer.TransferStatusId == 2;
                }).ToList();

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Transfers");
                Console.WriteLine($"{"ID",-5}          {"From/To",-20}                 {"Amount",-10}");
                Console.WriteLine("--------------------------------------------------------------");

                // loop through transfers and display transfer info
                foreach (Transfer transfer in transfers)
                {
                    string otherUsername = "";
                    string toFrom = "";

                    if (transfer.AccountTo == UserService.GetUserId())
                    {
                        // pending transfer where I have requested money
                        toFrom = "From: ";
                        otherUsername = transfer.AccountFromUsername;
                    }
                    else
                    {
                        // pending transfer where someone requested money from me
                        toFrom = "To: ";
                        otherUsername = transfer.AccountToUsername;
                    }
                    Console.WriteLine($"{transfer.TransferId,-5}            {$"{toFrom}{otherUsername}",-20}              {transfer.Amount:C2}");
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
                        return MenuOptionResult.DoNotWaitAfterMenuSelection;
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
                            Console.WriteLine($"From: {transfer.AccountFromUsername}");
                            Console.WriteLine($"To: {transfer.AccountToUsername}");
                            Console.WriteLine("Type: " + ((transfer.TransferTypeId == 1) ? "Request" : "Send"));
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
                        return MenuOptionResult.DoNotWaitAfterMenuSelection;
                    }
                    foreach (API_User user in users)
                    {
                        // check if the userid is valid (in the list and not yourself, you can't send money to yourself)
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

        private MenuOptionResult RequestTEBucks()
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
                int fromUserId = -1;
                //loop until we find a user id that is actually in the list
                while (badInput)
                {
                    fromUserId = GetInteger("Enter ID of user you are requesting from (0 to cancel): ");
                    if (fromUserId == 0)
                    {
                        return MenuOptionResult.DoNotWaitAfterMenuSelection;
                    }
                    foreach (API_User user in users)
                    {
                        if (user.UserId == fromUserId && fromUserId != UserService.GetUserId())
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

                Account myAccount = accountDao.GetAccount(UserService.GetUserId());
                bool transferStarted = transferDao.RequestMoney(myAccount.AccountId, fromUserId, amount);
                if (transferStarted)
                {
                    Console.WriteLine("TRANSFER PENDING");
                }
                else
                {
                    Console.WriteLine("TRANSFER FAILED");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ViewPendingTransfers()
        {
            try
            {
                // in the future - change this to get pending transfers as the database / transfers grows
                List<Transfer> transfers = transferDao.GetTransfers().Where((transfer) =>
                {
                    // only interested in pending transfers
                    return transfer.TransferStatusId == 1;
                }).ToList();

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Pending Transfers");
                Console.WriteLine($"{"ID",-5}          {"From/To",-20}                 {"Amount",-10}");
                Console.WriteLine("--------------------------------------------------------------");

                // loop through transfers and display transfer info
                foreach (Transfer transfer in transfers)
                {
                    string otherUsername = "";
                    string toFrom = "";

                    if (transfer.AccountTo == UserService.GetUserId())
                    {
                        // pending transfer where I have requested money
                        toFrom = "From: ";
                        otherUsername = transfer.AccountFromUsername;
                    }
                    else
                    {
                        // pending transfer where someone requested money from me
                        toFrom = "To: ";
                        otherUsername = transfer.AccountToUsername;
                    }
                    Console.WriteLine($"{transfer.TransferId,-5}            {$"{toFrom}{otherUsername}",-20}              {transfer.Amount:C2}");
                }

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("");
                bool badInput = true;
                int transferId = -1;

                //loop until we find a valid transfer ID
                while (badInput)
                {

                    transferId = GetInteger("Enter Transfer ID to approve/reject (0 to cancel): ");
                    if (transferId == 0)
                    {
                        return MenuOptionResult.DoNotWaitAfterMenuSelection;
                    }
                    foreach (Transfer transfer in transfers)
                    {
                        // if they entered a valid transferId and they are the account that the transfer would take money out of
                        if (transfer.TransferId == transferId && transfer.AccountFrom==UserService.GetUserId())
                        {
                            Console.Clear();
                            Console.WriteLine("1: Approve");
                            Console.WriteLine("2: Reject");
                            Console.WriteLine("0: Don't approve or reject");
                            Console.WriteLine("---------");
                            while (badInput)
                            {
                                int decision = GetInteger("Please choose an option: ");
                                if (decision == 1)
                                {
                                    // check to make sure your balance has enough money in it to transfer to the other account
                                    Account myAcct = accountDao.GetAccount(UserService.GetUserId());
                                    if (transfer.Amount > myAcct.Balance)
                                    {
                                        Console.WriteLine("Insufficient balance");
                                        return MenuOptionResult.WaitAfterMenuSelection;
                                    }
                                    //update status to approved
                                    transfer.TransferStatusId = 2;
                                    badInput = false;
                                    //maybe update the below 11 lines of code to a method since its repeated 3x here
                                    bool updateStatus = transferDao.UpdateRequestStatus(transfer);
                                    if (updateStatus)
                                    {
                                        Console.WriteLine("Success!");
                                        return MenuOptionResult.WaitAfterMenuSelection;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error");
                                        return MenuOptionResult.WaitAfterMenuSelection;
                                    }
                                }
                                else if (decision == 2)
                                {
                                    //update status to rejected
                                    transfer.TransferStatusId = 3;
                                    badInput = false;
                                    bool updateStatus = transferDao.UpdateRequestStatus(transfer);
                                    if (updateStatus)
                                    {
                                        Console.WriteLine("Success!");
                                        return MenuOptionResult.WaitAfterMenuSelection;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error");
                                        return MenuOptionResult.WaitAfterMenuSelection;
                                    }
                                }
                                else if (decision == 0)
                                {
                                    badInput = false;
                                    return MenuOptionResult.DoNotWaitAfterMenuSelection;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid option");
                                }
                            }
                        }

                        //if they entered a valid transferId and they are the account that requested the transfer
                        else if (transfer.TransferId == transferId && transfer.AccountTo == UserService.GetUserId())
                        {
                            Console.Clear();
                            Console.WriteLine("1: Reject");
                            Console.WriteLine("0: Don't reject");
                            Console.WriteLine("---------");
                            while (badInput)
                            {
                                int decision = GetInteger("Please choose an option: ");
                                if (decision == 1)
                                {
                                    //update status to rejected
                                    transfer.TransferStatusId = 3;
                                    badInput = false;
                                    bool updateStatus = transferDao.UpdateRequestStatus(transfer);
                                    if (updateStatus)
                                    {
                                        Console.WriteLine("Success!");
                                        return MenuOptionResult.WaitAfterMenuSelection;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error");
                                        return MenuOptionResult.WaitAfterMenuSelection;
                                    }
                                }
                                else if (decision == 0)
                                {
                                    badInput = false;
                                    return MenuOptionResult.DoNotWaitAfterMenuSelection;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid option");
                                }
                            }
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

    }
}
