using HotelReservationsClient.DAL;
using HotelReservationsClient.Models;
using MenuFramework;
using System;
using System.Collections.Generic;

namespace HotelReservationsClient.Views
{
    public class MainMenu : ConsoleMenu
    {
        private IAccountDao accountDao;
        private IHotelDao hotelDao;
        private IReservationDao reservationDao;

        private ConsoleService consoleService = new ConsoleService();

        public MainMenu(IAccountDao accountDao, IHotelDao hotelDao, IReservationDao reservationDao)
        {
            this.accountDao = accountDao;
            this.hotelDao = hotelDao;
            this.reservationDao = reservationDao;

            Configure(c =>
            {
                c.Title = "Welcome to Online Hotels! Please make a selection:";
                c.ItemForegroundColor = ConsoleColor.Yellow;
                c.SelectedItemForegroundColor = ConsoleColor.DarkYellow;
            });
        }

        protected override void RebuildMenuOptions()
        {
            ClearOptions();
            AddOption("List Hotels", ListHotels)
                .AddOption("List Reservations for Hotel", ListReservations)
                .AddOption("Create new Reservation for Hotel", NewReservation)
                .AddOption("Update existing Reservation for Hotel", UpdateReservation)
                .AddOption("Delete Reservation", DeleteReservation);

            if (accountDao.LoggedIn)
            {
                AddOption("Log Out", Logout);
            }
            else
            {
                AddOption("Log In", Login);
            }

            AddOption("Exit", Exit);
        }

        protected override void OnAfterShow()
        {
            SetColor(ConsoleColor.Green);

            // TODO 14: Display the logged in user name


            ResetColor();
        }

        private MenuOptionResult Logout()
        {
            accountDao.Logout();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        private MenuOptionResult Login()
        {
            string username = GetString("User name:", true);
            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Login cancelled by user");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            string password = GetString("Password:", true);
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Login cancelled by user");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            try
            {
                bool login = accountDao.Login(username, password);
                if (!login)
                {
                    Console.WriteLine("Invalid username or password");
                    return MenuOptionResult.WaitAfterMenuSelection;
                }
                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid username or password");
                return MenuOptionResult.WaitAfterMenuSelection;
            }
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
                return MenuOptionResult.WaitAfterMenuSelection;
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
