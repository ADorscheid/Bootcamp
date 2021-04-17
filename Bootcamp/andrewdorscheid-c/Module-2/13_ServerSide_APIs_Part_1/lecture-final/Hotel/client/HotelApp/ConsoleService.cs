using HTTP_Web_Services_POST_PUT_DELETE_lecture.Models;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture
{
    class ConsoleService
    {

        //Print methods

        public void PrintHotels(List<Hotel> hotels)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotels");
            Console.WriteLine("--------------------------------------------");
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(hotel.Id + ": " + hotel.Name);
            }
        }

        public void PrintHotel(Hotel hotel)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotel Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + hotel.Id);
            Console.WriteLine(" Name: " + hotel.Name);
            Console.WriteLine(" Stars: " + hotel.Stars);
            Console.WriteLine(" Rooms Available: " + hotel.RoomsAvailable);
            Console.WriteLine(" Cover Image: " + hotel.CoverImage);
        }

        public void PrintReservations(List<Reservation> reservations, int hotelId = -1)
        {
            string msg = hotelId == -1 ? "All Reservations" : "Reservations for hotel: " + hotelId;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(msg);
            Console.WriteLine("--------------------------------------------");
            if (reservations.Count > 0)
            {
                foreach (Reservation reservation in reservations)
                {
                    PrintReservationDetails(reservation);
                }
            }
            else
            {
                Console.WriteLine("There are no reservations for hotel: " + hotelId);
            }
        }

        private void PrintReservationDetails(Reservation reservation)
        {
            Console.WriteLine(" Id: " + reservation.Id);
            Console.WriteLine(" Hotel ID: " + reservation.HotelId);
            Console.WriteLine(" Name: " + reservation.FullName);
            Console.WriteLine(" Check-in Date: " + reservation.CheckinDate);
            Console.WriteLine(" Check-out Date: " + reservation.CheckoutDate);
            Console.WriteLine(" Guests: " + reservation.Guests);
            Console.WriteLine("");
        }
    }
}
