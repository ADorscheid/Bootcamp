﻿using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.DAL
{
    public class TransferApiDAO : ITransferDAO
    {
        private readonly RestClient client;

        public TransferApiDAO(string api_url)
        {
            client = new RestClient(api_url);
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
        }

        // used for displaying transfers in main menu
        public List<Transfer> GetTransfers()
        {
            RestRequest request = new RestRequest($"Transfers");

            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                throw new Exception("Error occurred - unable to reach server: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }

        public bool SendMoney(int fromUserId, int toUserId, decimal amount)
        {
            RestRequest request = new RestRequest("transfers");

            //create new transfer with the info passed in
            Transfer newTransfer = new Transfer();
            newTransfer.AccountFrom = fromUserId;
            newTransfer.AccountTo = toUserId;
            newTransfer.Amount = amount;
            newTransfer.TransferTypeId = 2;
            //all sendmoneys are approved always
            newTransfer.TransferStatusId = 2;

            //pass through
            request.AddJsonBody(newTransfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);
            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                throw new Exception("Error occurred - unable to reach server: " + (int)response.StatusCode);
            }
            else
            {
                return true;
            }
        }

        public bool RequestMoney(int myAccountId, int requestAccountId, decimal amount)
        {
            RestRequest request = new RestRequest("transfers");

            //create new transfer with the info passed in
            Transfer newTransfer = new Transfer();
            newTransfer.AccountFrom = requestAccountId;
            newTransfer.AccountTo = myAccountId;
            newTransfer.Amount = amount;
            newTransfer.TransferTypeId = 1;
            // when a request is made it is always set to pending
            newTransfer.TransferStatusId = 1;

            //pass through
            request.AddJsonBody(newTransfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);
            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                throw new Exception("Error occurred - unable to reach server: " + (int)response.StatusCode);
            }
            else
            {
                return true;
            }
        }

        public bool UpdateRequestStatus(Transfer transfer)
        {
            RestRequest request = new RestRequest($"transfers/{transfer.TransferId}");

            request.AddJsonBody(transfer);

            IRestResponse<Transfer> response = client.Put<Transfer>(request);
            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                throw new Exception("Error occurred - unable to reach server: " + (int)response.StatusCode);
            }
            else
            {
                return true;
            }
        }
    }
}
