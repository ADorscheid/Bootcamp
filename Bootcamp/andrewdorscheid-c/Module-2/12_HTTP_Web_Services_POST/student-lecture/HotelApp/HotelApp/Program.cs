using HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL;
using HTTP_Web_Services_POST_PUT_DELETE_lecture.Views;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture
{
    class Program
    {
        private static readonly string apiUrl = "http://localhost:3000/";

        static void Main(string[] args)
        {
            // TODO 01: Note the new architecture: using DAOs for API access also.
            IHotelDao hotelDao = new HotelApiDao(apiUrl);
            IReviewDao reviewDao = new ReviewApiDao(apiUrl);
            IReservationDao reservationDao = new ReservationApiDao(apiUrl);

            new MainMenu(hotelDao, reviewDao, reservationDao).Show();
        }
    }
}
