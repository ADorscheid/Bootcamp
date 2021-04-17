using HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL;
using HTTP_Web_Services_POST_PUT_DELETE_lecture.Views;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture
{
    class Program
    {
        //private static readonly string apiUrl = "https://localhost:44322";
        private static readonly string apiUrl = "https://tehotelreservations.azurewebsites.net";
        static void Main(string[] args)
        {
            IHotelDao hotelDao = new HotelApiDao(apiUrl);
            IReviewDao reviewDao = new ReviewApiDao(apiUrl);
            IReservationDao reservationDao = new ReservationApiDao(apiUrl);

            new MainMenu(hotelDao, reviewDao, reservationDao).Show();
        }
    }
}
