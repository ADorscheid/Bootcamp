using HotelReservations.Models;
using System.Collections.Generic;

namespace HotelReservations.Dao
{
    public interface IReservationDao
    {
        Reservation Create(Reservation reservation);
        List<Reservation> FindByHotel(int hotelId);
        List<Reservation> FindByName(string nameContains);
        Reservation Get(int id);
        List<Reservation> List();
        Reservation Update(Reservation res);
        bool Delete(int id);

    }
}