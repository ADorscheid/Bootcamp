using HTTP_Web_Services_POST_PUT_DELETE_lecture.Models;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL
{
    public interface IHotelDao
    {
        List<Hotel> GetHotel(int hotelId);
        List<Hotel> GetHotels();
        List<Hotel> GetHotelsForRating(int starRating);
    }
}