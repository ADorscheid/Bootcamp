using HotelReservationsClient.Models;
using System.Collections.Generic;

namespace HotelReservationsClient.DAL
{
    public interface IHotelDao : IApiDao
    {
        List<Hotel> GetHotel(int hotelId);
        List<Hotel> GetHotels();
        List<Hotel> GetHotelsForRating(int starRating);
    }
}