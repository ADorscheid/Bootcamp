using HotelReservationsClient.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace HotelReservationsClient.DAL
{
    public class AccountApiDao : ApiDao, IAccountDao
    {
        public AccountApiDao(string apiUrl) : base(apiUrl) { }

        public bool Login(string submittedName, string submittedPass)
        {
            var credentials = new { username = submittedName, password = submittedPass }; //this gets converted to JSON by RestSharp
            RestRequest request = new RestRequest("login");
            request.AddJsonBody(credentials);
            IRestResponse<User> response = client.Post<User>(request);

            CheckResponse(response); // Will throw if there's an error

            // TODO 12: If the login succeeeds, create the User object and add a new Authenticator 
            //  to the client for subsequent calls
            User = response.Data;
            client.Authenticator = new JwtAuthenticator(User.Token);

            return true;
        }


        // TODO 13: To log out, we simply "forget" the token.  There is no need to contact the server.
        public void Logout()
        {
            User = null;
            client.Authenticator = null;
        }

    }
}
