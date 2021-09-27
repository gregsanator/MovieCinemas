using MovieCinemas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static MovieCinemas.DTO.CinemaRooms;

namespace MovieCinemas.Controllers
{
    public class CinemaRoomsController : ApiController
    {
        [HttpGet]
        [Route("api/moviescinemas/rooms/list")]
        public IHttpActionResult List()
        {
            CinemaRoomsService service = new CinemaRoomsService();
            List<CinemaRoomsList> list = service.List();
            return Ok(list);
        }

        [HttpGet]
        [Route("api/moviecinemas/rooms/details/{id}")]
        public IHttpActionResult Details(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api/moviecinemas/rooms/save")]
        public IHttpActionResult Save()
        {
            return Ok();
        }
    }
}