using HotelReservationsClient.Models;
using RestSharp;
using System.Collections.Generic;

namespace HotelReservationsClient.DAL
{
    class HotelApiDao : ApiDao, IHotelDao
    {
        public HotelApiDao(string apiUrl) : base(apiUrl) { }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest("hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            CheckResponse(response); // Will throw if there's an error

            return response.Data;
        }
        public List<Hotel> GetHotel(int hotelId)
        {
            RestRequest request = new RestRequest($"hotels/{hotelId}");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            CheckResponse(response); // Will throw if there's an error

            return response.Data;
        }
        public List<Hotel> GetHotelsForRating(int starRating)
        {
            RestRequest request = new RestRequest($"hotels?stars={starRating}");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            CheckResponse(response); // Will throw if there's an error

            return response.Data;
        }
    }
}
