using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservations.Dao
{
    public class ReservationFakeDao : IReservationDao
    {

        // each request of the controller creates a new instance of the dao
        // this is to preserve the data on each request until we get to dependency injection
        private static List<Reservation> Reservations { get; set; }

        public ReservationFakeDao()
        {
            if (Reservations == null)
            {
                Reservations = new List<Reservation>
                {
                    new Reservation(1, 1, "John Smith", DateTime.Today, DateTime.Today.AddDays(3), 2),
                    new Reservation(2, 1, "Sam Turner", DateTime.Today, DateTime.Today.AddDays(5), 4),
                    new Reservation(3, 1, "Mark Johnson", DateTime.Today.AddDays(7), DateTime.Today.AddDays(10), 2),
                    new Reservation(4, 2, "Jospeh Williams", DateTime.Today.AddDays(2), DateTime.Today.AddDays(4), 2)
                };
            }
        }

        public List<Reservation> List()
        {
            return Reservations;
        }

        public Reservation Get(int id)
        {
            foreach (var reservation in Reservations)
            {
                if (reservation.Id == id)
                {
                    return reservation;
                }
            }

            return null;
        }

        public List<Reservation> FindByHotel(int hotelId)
        {
            List<Reservation> matched = new List<Reservation>();
            foreach (Reservation r in Reservations)
            {
                if (r.HotelId == hotelId)
                {
                    matched.Add(r);
                }
            }
            return matched;
        }

        public Reservation Create(Reservation reservation)
        {
            int maxId = Reservations.Max(r => r.Id) ?? 0;
            reservation.Id = maxId + 1;
            Reservations.Add(reservation);
            return reservation;
        }

        public Reservation Update(Reservation res)
        {
            // Find the existing reservation in the DB
            Reservation oldRes = Get(res.Id.Value);

            // If found, update all its properties
            if (oldRes != null)
            {
                oldRes.Guests = res.Guests;
                oldRes.CheckinDate = res.CheckinDate;
                oldRes.CheckoutDate = res.CheckoutDate;
                oldRes.FullName = res.FullName;
            }
            return oldRes;
        }

        public bool Delete(int id)
        {
            // Find the existing res
            Reservation res = Get(id);

            // Not found
            if (res == null)
            {
                return false;
            }

            // Found - Delete it
            Reservations.Remove(res);
            return true;
        }
    }
}
