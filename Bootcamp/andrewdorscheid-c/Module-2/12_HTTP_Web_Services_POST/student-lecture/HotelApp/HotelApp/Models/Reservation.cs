using System;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture.Models
{
    public class Reservation
    {
        public int? Id { get; set; }
        public int HotelId { get; set; }
        public string FullName { get; set; }
        public DateTime CheckinDate { get; set; } = DateTime.MinValue;
        public DateTime CheckoutDate { get; set; } = DateTime.MinValue;
        public int Guests { get; set; }

        public Reservation()
        {
            //must have parameterless constructor to use as a type parameter (i.e., client.Get<Reservation>())
        }

        public bool IsValid
        {
            get
            {
                return HotelId != 0 && FullName != null && CheckinDate != DateTime.MinValue && CheckoutDate != DateTime.MinValue && Guests != 0;
            }
        }

        public override string ToString()
        {
            return $"{FullName} ({CheckinDate.ToString("d")} to {CheckoutDate.ToString("d")})";
        }
    }
}
