using HTTP_Web_Services_POST_PUT_DELETE_lecture.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL
{
    class HotelApiDao : IHotelDao
    {
        private RestClient client;

        public HotelApiDao(string api_url)
        {
            client = new RestClient(api_url);
        }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest("hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            // TODO 02: Handle errors in the Hotel API client. Check statuses and throw an exception if there are errors.

            return response.Data;
        }
        public List<Hotel> GetHotel(int hotelId)
        {
            RestRequest request = new RestRequest($"hotels/{hotelId}");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            // TODO 02: Handle errors in the Hotel API client. Check statuses and throw an exception if there are errors.

            return response.Data;
        }
        public List<Hotel> GetHotelsForRating(int starRating)
        {
            RestRequest request = new RestRequest($"hotels?stars={starRating}");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            // TODO 02: Handle errors in the Hotel API client. Check statuses and throw an exception if there are errors.

            return response.Data;
        }
    }
}
