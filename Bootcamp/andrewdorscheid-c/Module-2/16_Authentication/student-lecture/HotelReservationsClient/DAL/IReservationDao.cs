using HotelReservationsClient.Models;
using System.Collections.Generic;

namespace HotelReservationsClient.DAL
{
    public interface IReservationDao : IApiDao
    {
        Reservation AddReservation(Reservation newReservation);
        bool DeleteReservation(int reservationId);
        Reservation GetReservation(int reservationId);
        List<Reservation> GetReservations(int hotelId = 0);
        Reservation UpdateReservation(Reservation reservationToUpdate);
    }
}