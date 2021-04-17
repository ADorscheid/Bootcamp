using HotelReservationsClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace HotelReservationsClient.DAL
{
    class ReservationApiDao : ApiDao, IReservationDao
    {
        public ReservationApiDao(string apiUrl) : base(apiUrl) { }

        public List<Reservation> GetReservations(int hotelId = 0)
        {
            string url;
            if (hotelId != 0)
                url = $"hotels/{hotelId}/reservations";
            else
                url = "reservations";

            RestRequest request = new RestRequest(url);
            IRestResponse<List<Reservation>> response = client.Get<List<Reservation>>(request);
            CheckResponse(response); // Will throw if there's an error

            return response.Data;
        }

        public Reservation GetReservation(int reservationId)
        {
            RestRequest request = new RestRequest($"reservations/{reservationId}");
            IRestResponse<Reservation> response = client.Get<Reservation>(request);
            CheckResponse(response); // Will throw if there's an error

            return response.Data;
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            RestRequest request = new RestRequest("reservations");
            request.AddJsonBody(newReservation);
            IRestResponse<Reservation> response = client.Post<Reservation>(request);
            CheckResponse(response); // Will throw if there's an error

            return response.Data;
        }

        public Reservation UpdateReservation(Reservation reservationToUpdate)
        {
            RestRequest request = new RestRequest($"reservations/{reservationToUpdate.Id}");
            request.AddJsonBody(reservationToUpdate);
            IRestResponse<Reservation> response = client.Put<Reservation>(request);
            CheckResponse(response); // Will throw if there's an error

            return response.Data;
        }

        public bool DeleteReservation(int reservationId)
        {
            RestRequest request = new RestRequest($"reservations/{reservationId}");
            IRestResponse response = client.Delete(request);
            CheckResponse(response); // Will throw if there's an error

            return true;
        }
    }
}
