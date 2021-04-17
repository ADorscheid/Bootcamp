using HTTP_Web_Services_POST_PUT_DELETE_lecture.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL
{
    class ReservationApiDao : IReservationDao
    {
        private RestClient client;

        public ReservationApiDao(string api_url)
        {
            client = new RestClient(api_url);
        }

        public List<Reservation> GetReservations(int hotelId = 0)
        {
            // TODO 03: Note these two additional GETs already coded (for Reservations)
            string url;
            if (hotelId != 0)
                url = $"hotels/{hotelId}/reservations";
            else
                url = "reservations";

            RestRequest request = new RestRequest(url);
            IRestResponse<List<Reservation>> response = client.Get<List<Reservation>>(request);
            CheckResponse(response);
            return response.Data;
        }

        public Reservation GetReservation(int reservationId)
        {
            // TODO 03: Note these two additional GETs already coded (for Reservations)
            RestRequest request = new RestRequest($"reservations/{reservationId}");
            IRestResponse<Reservation> response = client.Get<Reservation>(request);
            CheckResponse(response);
            return response.Data;
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            // TODO 04: Implement the API call to Post a new Reservation
            RestRequest request = new RestRequest("reservations");
            request.AddJsonBody(newReservation);
            IRestResponse<Reservation> response = client.Post<Reservation>(request);

            CheckResponse(response);

            return response.Data;
        }

        public Reservation UpdateReservation(Reservation reservationToUpdate)
        {
            // TODO 05: Implement the API call to Put an existing Reservation
            RestRequest request = new RestRequest($"reservations/{reservationToUpdate.Id}");
            request.AddJsonBody(reservationToUpdate);

            IRestResponse<Reservation> response = client.Put<Reservation>(request);

            CheckResponse(response);

            return response.Data;
        }

        public bool DeleteReservation(int reservationId)
        {
            // TODO 06: Implement the API call to Delete an existing Reservation
            RestRequest request = new RestRequest($"reservations/{reservationId}");

            IRestResponse response = client.Delete(request);

            CheckResponse(response);

            return true;

        }

        private void CheckResponse(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
        }
    }
}
