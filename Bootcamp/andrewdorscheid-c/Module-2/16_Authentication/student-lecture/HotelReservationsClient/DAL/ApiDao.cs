using HotelReservationsClient.Models;
using RestSharp;
using System;
using System.Net;

namespace HotelReservationsClient.DAL
{
    // TODO 10: Note that we re-factored the DAOs. Since this is an api that requires authentication, 
    //  we create a base class that tracks the current user and maintains a client authenticator.
    //  We also factored a CheckResponse method to check status codes, since every API call needs 
    //  to do this.
    public class ApiDao
    {
        // We make the user variable static so that all instances of any derived 
        // DAO has access to the ONE user (who is either logged in or null)
        static private User user = null;

        public User User
        {
            get
            {
                return user;
            }
            protected set
            {
                user = value;
            }
        }

        // We make the client variable static because at login time, we attach an authenticator to 
        // the client.  We want ALL ApiDao objects to use this same authenticated client.
        static protected RestClient client = null;

        public bool LoggedIn
        {
            get
            {
                return (user != null);
            }
        }

        public ApiDao(string apiUrl)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl);
            }
        }

        // TODO 11: Note the new error handling technique.  After any call to the api, CheckResponse is called.
        //          It will throw if there is an error or bad status code, so the callers really don't need
        //          to do anything special.
        //      Also notice the conversion of certain status codes to human-readable errors.
        protected void CheckResponse(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Authorization is required for this option. Please log in.");
                }
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new Exception("You do not have permission to perform the requested action");
                }

                throw new Exception($"Error occurred - received non-success response: {response.StatusCode} ({(int)response.StatusCode})");
            }
        }

    }
}
