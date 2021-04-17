using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;

namespace HotelReservations.Controllers
{
    [Route("hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        /***************
         * Implement these endpoints:
         * 
         *  /hotels             GET     - list of all hotels
         *  /hotels/{id}        GET     - get a single hotel
         *  
         ***************/
        private IHotelDao hotelDao;

        public HotelsController(IHotelDao hotelDao)
        {
            this.hotelDao = hotelDao;
        }

        [HttpGet()]
        public List<Hotel> ListHotels()
        {
            return hotelDao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotel(int id)
        {
            Hotel hotel = hotelDao.Get(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }
    }
}
