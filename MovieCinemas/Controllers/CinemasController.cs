using MovieCinemas.DTO;
using MovieCinemas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static MovieCinemas.DTO.CinemaRooms;

namespace MovieCinemas.Controllers
{
    public class CinemasController : ApiController
    {
        [Route("api/moviecinemas/cinemas/list")]
        [HttpGet]
        public IHttpActionResult List()
        {
            CinemasService cs = new CinemasService();
            List<CinemasList> crl = cs.List();
            return Ok(crl);
        }

        [Route("api/moviecinemas/cinemas/details/{id}")]
        [HttpGet]
        public IHttpActionResult Details(Guid id)
        {
            CinemasService cs = new CinemasService();
            CinemasDetails cd = cs.Details(id);
            return Ok(cd);
        }

        [Route("api/moviecinemas/cinemas/save")]
        [HttpPost]
        public IHttpActionResult Save(CinemasSave csave)
        {
            CinemasService cs = new CinemasService();
            bool success = cs.Save(csave);
            return Ok(success);
        }

        [Route("api/moviecinemas/cinemas/enable{id}")]
        [HttpPost]
        public IHttpActionResult Enable(Guid id)
        {
            CinemasService service = new CinemasService();
            bool success = service.Enable(id);
            return Ok(success);
        }
    }
}