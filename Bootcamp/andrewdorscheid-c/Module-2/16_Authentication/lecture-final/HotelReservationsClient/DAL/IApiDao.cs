using HotelReservationsClient.Models;

namespace HotelReservationsClient.DAL
{
    public interface IApiDao
    {
        bool LoggedIn { get; }

        User User { get; }
    }
}