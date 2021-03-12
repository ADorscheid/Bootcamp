using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.DAL
{
    class UserApiDAO : IUserApiDAO
    {
        private readonly RestClient client;

        public UserApiDAO(string api_url)
        {
            client = new RestClient(api_url);
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
        }

        public List<API_User> GetUsers()
        {
            RestRequest request = new RestRequest($"users");
            //users

            IRestResponse<List<API_User>> response = client.Get<List<API_User>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                throw new Exception("Error occurred - unable to reach server: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }
    }
}
