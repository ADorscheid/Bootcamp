using HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL;
using HTTP_Web_Services_POST_PUT_DELETE_lecture.Models;
using MenuFramework;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture.Views
{
    public class MainMenu : ConsoleMenu
    {
        private IHotelDao hotelDao;
        private IReviewDao reviewDao;
        private IReservationDao reservationDao;

        private ConsoleService consoleService = new ConsoleService();

        public MainMenu(IHotelDao hotelDao, IReviewDao reviewDao, IReservationDao reservationDao)
        {
            this.hotelDao = hotelDao;
            this.reviewDao = reviewDao;
            this.reservationDao = reservationDao;

            AddOption("List Hotels", ListHotels)
                .AddOption("List Reservations for Hotel", ListReservations)
                .AddOption("Create new Reservation for Hotel", NewReservation)
                .AddOption("Update existing Reservation for Hotel", UpdateReservation)
                .AddOption("Delete Reservation", DeleteReservation)
                .AddOption("Exit", Exit)
                .Configure(c =>
                {
                    c.Title = "Welcome to Online Hotels! Please make a selection:";
                    c.ItemForegroundColor = ConsoleColor.Yellow;
                    c.SelectedItemForegroundColor = ConsoleColor.DarkYellow;
                });
        }
        private MenuOptionResult ListHotels()
        {
            // Call the api to get hotels (/hotels)
            try
            {
                List<Hotel> hotels = hotelDao.GetHotels();
                consoleService.PrintHotels(hotels);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ListReservations()
        {
            try
            {
                List<Hotel> hotels = hotelDao.GetHotels();
                ConsoleMenu hotelMenu = new ConsoleMenu()
                    .AddOptionRange<Hotel>(hotels, ListReservations)
                    .AddOption("Cancel", Close)
                    .Configure(c => { c.Title = "Select a hotel:"; });
                return hotelMenu.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return MenuOptionResult.WaitAfterMenuSelection;
            }
        }

        private MenuOptionResult ListReservations(Hotel hotel)
        {
            try
            {
                List<Reservation> reservations = reservationDao.GetReservations(hotel.Id);
                consoleService.PrintReservations(reservations, hotel.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult NewReservation()
        {
            try
            {
                // Create new reservation
                Reservation reservationToAdd = new Reservation();
                reservationToAdd.HotelId = GetInteger("Hotel Id:");
                reservationToAdd.FullName = GetString("Full Name:");
                reservationToAdd.CheckinDate = GetDate("Check In:", DateTime.Now);
                reservationToAdd.CheckoutDate = GetDate("Check Out:", DateTime.Now.AddDays(1));
                reservationToAdd.Guests = GetInteger("Number of Guests:");

                if (reservationToAdd.IsValid)
                {
                    Reservation addedReservation = reservationDao.AddReservation(reservationToAdd);
                    if (addedReservation != null)
                    {
                        Console.WriteLine("Reservation successfully added.");
                    }
                    else
                    {
                        Console.WriteLine("Reservation not added.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult UpdateReservation()
        {
            try
            {
                // Update an existing reservation
                List<Reservation> reservations = reservationDao.GetReservations();
                ConsoleMenu resMenu = new ConsoleMenu()
                    .AddOptionRange<Reservation>(reservations, UpdateReservation)
                    .AddOption("Cancel", Close)
                    .Configure(c => { c.Title = "Select a reservation to UPDATE:"; });
                resMenu.Show();
                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }
        }

        private MenuOptionResult UpdateReservation(Reservation reservation)
        {
            try
            {
                reservation.FullName = GetString("Full Name:", false, reservation.FullName);
                reservation.CheckinDate = GetDate("Check In:", reservation.CheckinDate);
                reservation.CheckoutDate = GetDate("Check Out:", reservation.CheckoutDate);
                reservation.Guests = GetInteger("Number of Guests:", reservation.Guests);

                if (reservation.IsValid)
                {
                    Reservation updatedReservation = reservationDao.UpdateReservation(reservation);
                    if (updatedReservation != null)
                    {
                        Console.WriteLine("Reservation successfully updated.");
                    }
                    else
                    {
                        Console.WriteLine("Reservation not updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return MenuOptionResult.WaitThenCloseAfterSelection;
        }

        private MenuOptionResult DeleteReservation()
        {
            try
            {
                // Update an existing reservation
                List<Reservation> reservations = reservationDao.GetReservations();
                ConsoleMenu resMenu = new ConsoleMenu()
                    .AddOptionRange<Reservation>(reservations, DeleteReservation)
                    .AddOption("Cancel", Close)
                    .Configure(c =>
                    {
                        c.Title = "Select a reservation to DELETE:";
                        c.ItemForegroundColor = ConsoleColor.Red;
                    });
                resMenu.Show();
                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return MenuOptionResult.WaitAfterMenuSelection;
            }
        }

        private MenuOptionResult DeleteReservation(Reservation reservation)
        {
            try
            {
                // Delete reservation
                if (!GetBool($"Are you sure you want to delete the reservation for {reservation.FullName}?", false))
                {
                    return MenuOptionResult.DoNotWaitAfterMenuSelection;
                }

                if (reservationDao.DeleteReservation(reservation.Id.Value))
                {
                    Console.WriteLine("Reservation was deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return MenuOptionResult.WaitThenCloseAfterSelection;
        }
    }
}
