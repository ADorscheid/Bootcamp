using System;

namespace HotelReservations.Models
{
    public class Reservation
    {
        public int? Id { get; set; }
        public int HotelId { get; set; }
        public string FullName { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int Guests { get; set; }

        public Reservation(int? id, int hotelId, string fullName, DateTime checkinDate, DateTime checkoutDate, int guests)
        {
            Id = id ?? new Random().Next(100, int.MaxValue);
            HotelId = hotelId;
            FullName = fullName;
            CheckinDate = checkinDate;
            CheckoutDate = checkoutDate;
            Guests = guests;
        }
    }
}
