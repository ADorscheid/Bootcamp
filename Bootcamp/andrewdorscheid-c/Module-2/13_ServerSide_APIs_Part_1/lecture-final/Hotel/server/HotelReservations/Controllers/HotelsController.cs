using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;

namespace HotelReservations.Controllers
{
    [Route("/")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelDao hotelDao;
        private IReservationDao reservationDao;

        public HotelsController()
        {
            hotelDao = new HotelFakeDao();
            reservationDao = new ReservationFakeDao();
        }

        [HttpGet("hotels")]
        public List<Hotel> ListHotels()
        {
            return hotelDao.List();
        }

        [HttpGet("hotels/{id}")]
        public Hotel GetHotel(int id)
        {
            Hotel hotel = hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }

            return null;
        }

        [HttpGet("hotels/{hotelId}/reservations")]
        public List<Reservation> GetReservations(int hotelId)
        {
            return reservationDao.FindByHotel(hotelId);
        }

        // Get all reservations in the DB
        [HttpGet("reservations")]
        public List<Reservation> GetReservations()
        {
            return reservationDao.List();
        }

        // Create a new reservation
        [HttpPost("reservations")]
        public ActionResult<Reservation> CreateReservation(Reservation newRes)
        {
            Reservation res = reservationDao.Create(newRes);

            return Created($"/reservations/{res.Id }", res);
        }

        // Update an existing reservation
        [HttpPut("reservations/{resId}")]
        public ActionResult<Reservation> UpdateReservation(int resId, Reservation updatedRes)
        {
            // Make sure the id's match
            if (resId != updatedRes.Id)
            {
                return UnprocessableEntity();
            }

            updatedRes = reservationDao.Update(updatedRes);

            return Ok(updatedRes);
        }

        // Delete a reservation
        [HttpDelete("reservations/{idToDelete}")]
        public ActionResult DeleteReservation(int idToDelete)
        {
            if (reservationDao.Delete(idToDelete))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


    }
}
