using HotelReservationsClient.DAL;
using HotelReservationsClient.Models;
using HotelReservationsClient.Views;
using System;
using System.Collections.Generic;

namespace HotelReservationsClient
{
    class Program
    {
        private static readonly string apiUrl = "https://localhost:44322";

        static void Main(string[] args)
        {
            IAccountDao accountDao = new AccountApiDao(apiUrl);
            IHotelDao hotelDao = new HotelApiDao(apiUrl);
            IReservationDao reservationDao = new ReservationApiDao(apiUrl);

            new MainMenu(accountDao, hotelDao, reservationDao).Show();
        }
    }
}
