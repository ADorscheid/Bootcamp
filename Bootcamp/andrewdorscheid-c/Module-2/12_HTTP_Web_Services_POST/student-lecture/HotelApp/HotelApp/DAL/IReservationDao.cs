using HTTP_Web_Services_POST_PUT_DELETE_lecture.Models;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL
{
    public interface IReservationDao
    {
        Reservation AddReservation(Reservation newReservation);
        bool DeleteReservation(int reservationId);
        Reservation GetReservation(int reservationId);
        List<Reservation> GetReservations(int hotelId = 0);
        Reservation UpdateReservation(Reservation reservationToUpdate);
    }
}