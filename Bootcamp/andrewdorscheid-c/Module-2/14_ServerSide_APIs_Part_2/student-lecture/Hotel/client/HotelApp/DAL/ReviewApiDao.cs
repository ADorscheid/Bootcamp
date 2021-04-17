using HTTP_Web_Services_POST_PUT_DELETE_lecture.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL
{
    class ReviewApiDao : IReviewDao
    {
        private RestClient client;

        public ReviewApiDao(string api_url)
        {
            client = new RestClient(api_url);
        }

        public List<Review> GetReviews()
        {
            RestRequest request = new RestRequest("reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }
        public List<Review> GetReviews(int hotelId)
        {
            RestRequest request = new RestRequest($"hotels/{hotelId}/reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }

    }
}
