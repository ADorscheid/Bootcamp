using HotelReservations.Dao;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // TODO 07: All methods on this controller require a logged in user, so use the Authorize attribute
    //      at the controller level

    public class ReservationsController : ControllerBase
    {
        // TODO 08: Add additional authorization attributes for methods that require admin access.
        /***************
         * Implement these endpoints:
         * 
         * TODO 08: User must be an **admin** to do these methods
         *  /reservations       GET     - List all reservations
         *  /hotels/{id}/reservations GET - Get all reservations for a hotel
         *  /reservations/{id}  PUT     - Update a res
         *  /reservations/{id}  DELETE  - Delete a res

         * TODO 08: Any logged in user can do this (presumably to their own reservation)
         *  /reservations/{id}  GET     - get a single reservation
         *  /reservations       POST    - Add a new reservation
         *  
         ***************/

        private IReservationDao reservationDao;

        public ReservationsController(IReservationDao reservationDao)
        {
            this.reservationDao = reservationDao;
        }

        /// <summary>
        /// Get a list of all reservations in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Reservation> GetAllReservations()
        {
            return reservationDao.List();
        }

        /// <summary>
        /// Get the reservation given an id
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        [HttpGet("{reservationId}")]
        public ActionResult<Reservation> GetReservation(int reservationId)
        {
            Reservation res = reservationDao.Get(reservationId);
            if (res == null)
            {
                return NotFound();
            }

            return res;
        }

        [HttpGet("/hotels/{hotelId}/reservations")]
        public List<Reservation> GetReservationsForHotel(int hotelId)
        {
            return reservationDao.FindByHotel(hotelId);
        }

        [HttpPost]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            Reservation res = reservationDao.Create(reservation);
            return Created($"/reservations/{res.Id}", res);
        }

        [HttpPut("{id}")]
        public Reservation UpdateReservation(Reservation reservation)
        {
            return reservationDao.Update(reservation);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            if (reservationDao.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
