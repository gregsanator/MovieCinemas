using MovieCinemas.DTO;
using MovieCinemas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieCinemas.Controllers
{
    public class ReservationsController : ApiController
    {
        [Route("api/moviecinemas/reservations/list")]
        [HttpPost]
        public IHttpActionResult List(ReservationFilter filter)
        {
            ReservationsService service = new ReservationsService();
            List<ReservationsListItem> list = service.List(filter);           
            return Ok(list);
        }

        [Route("api/moviecinemas/reservations/details/{id}")]
        [HttpGet] // if we want to send a parameter to URL
        public IHttpActionResult Details(Guid id)
        {
            ReservationsService rs = new ReservationsService();
            ReservationsDetails rd = rs.Details(id);
            return Ok(rd);
        }

        [Route("api/moviecinemas/reservations/save")] // method attributes
        [HttpPost] // if we want to post an object
        public IHttpActionResult Save(ReservationsSave save)
        {
            ReservationsService rs = new ReservationsService();
            bool success = rs.Save(save);
            return Ok(success);
        }
    }
}