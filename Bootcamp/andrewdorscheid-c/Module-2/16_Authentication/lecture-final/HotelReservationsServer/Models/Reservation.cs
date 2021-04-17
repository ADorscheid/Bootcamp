using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservations.Models
{
    public class Reservation
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "The field `HotelId` is required.")]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "The field `FullName` is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "The field `CheckinDate` is required.")]
        public DateTime CheckinDate { get; set; }

        [Required(ErrorMessage = "The field `CheckoutDate` is required.")]
        public DateTime CheckoutDate { get; set; }

        [Range(1, 5, ErrorMessage = "The minimum number of guests is 1 and the maximum number is 5.")]
        public int Guests { get; set; }

        public Reservation(int? id, int hotelId, string fullName, DateTime checkinDate, DateTime checkoutDate, int guests)
        {
            Id = id ?? 0;
            HotelId = hotelId;
            FullName = fullName;
            CheckinDate = checkinDate;
            CheckoutDate = checkoutDate;
            Guests = guests;
        }
    }
}
