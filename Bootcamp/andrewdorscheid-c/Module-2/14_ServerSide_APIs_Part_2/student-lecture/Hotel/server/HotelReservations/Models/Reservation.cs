using System;

namespace HotelReservations.Models
{
    // TODO 03: Use Postman to show how we can enter invalid data
    /*** TODO 04: Add data validation attributes to protect the model data
    *          HotelId, FullName, Checkin, Checkout and Guests are all required
    *          The number of guests should be in the Range of 1 - 5
    *          Full name should be at least 6 characters long
    ***/

    public class Reservation
    {
        /// <summary>
        /// The confirmation number for this reservation
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// The id of the hotel this reservation is for
        /// </summary>
        public int HotelId { get; set; }
        /// <summary>
        /// Full name of the guest staying at the hotel
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Date of arrival
        /// </summary>
        public DateTime CheckinDate { get; set; }
        /// <summary>
        /// Date of departure
        /// </summary>
        public DateTime CheckoutDate { get; set; }
        /// <summary>
        /// Total number of guests expected to stay overnight in the room.
        /// </summary>
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
