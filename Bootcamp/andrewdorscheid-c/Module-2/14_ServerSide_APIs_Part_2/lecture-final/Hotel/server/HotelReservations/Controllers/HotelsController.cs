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

        public HotelsController(IHotelDao hotelDao, IReservationDao reservationDao)
        {
            this.hotelDao = hotelDao;
            this.reservationDao = reservationDao;
        }

        /// <summary>
        /// Get a list of all hotels.
        /// </summary>
        /// <returns>A JSON array of all hotels</returns>
        [HttpGet("hotels")]
        public List<Hotel> ListHotels()
        {
            return hotelDao.List();
        }


        /// <summary>
        /// Get a single hotel by its id.
        /// </summary>
        /// <param name="id">The identifier for the hotel</param>
        /// <returns>The hotel (as JSON) if found, 404 if not found.</returns>
        [HttpGet("hotels/{id}")]
        public ActionResult<Hotel> GetHotel(int id)
        {
            // TODO 01: Return 404 if the Id is not found (using NotFound()). Change return type to ActionResult<>
            Hotel hotel = hotelDao.Get(id);

            if (hotel != null)
            {
                return Ok(hotel);
            }

            return NotFound();
        }

        /// <summary>
        /// Get a list of all reservations for a single hotel.
        /// </summary>
        /// <param name="hotelId">The id of the hotel.</param>
        /// <returns>A json array of reservations for this hotel. If there are no reservations,
        /// or if the hotel does not exist, the array will be empty.</returns>
        [HttpGet("hotels/{hotelId}/reservations")]
        public List<Reservation> GetReservations(int hotelId)
        {
            return reservationDao.FindByHotel(hotelId);
        }

        // TODO 02: New Feature - Find all reservations by name
        // /reservations?name=john

        /// <summary>
        /// Get all reservations for all hotels in the system.
        /// </summary>
        /// <returns>a json array of all reservations.</returns>
        [HttpGet("reservations")]
        public List<Reservation> GetReservations(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return reservationDao.List();
            }
            else
            {
                return reservationDao.FindByName(name);
            }
        }

        /// <summary>
        /// Add a new reservation.
        /// </summary>
        /// <param name="newRes">A json object containing reservation information</param>
        /// <returns>The new reservation as a json object.</returns>
        [HttpPost("reservations")]
        public ActionResult<Reservation> CreateReservation(Reservation newRes)
        {
            Reservation res = reservationDao.Create(newRes);

            return Created($"/reservations/{res.Id }", res);
        }

        /// <summary>
        /// Update an existing reservation.
        /// </summary>
        /// <param name="resId">The confirmation number of the reservation.</param>
        /// <param name="updatedRes">A json object containing updated information</param>
        /// <returns>The updated reservation as a json object.</returns>
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

        /// <summary>
        /// Delete a reservation.
        /// </summary>
        /// <param name="idToDelete">Confirmation number of the reservation to delete.</param>
        /// <returns>204 No Content if successful or 404 Not Found if not.</returns>
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
