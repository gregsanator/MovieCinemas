using MovieCinemas.DTO;
using MovieCinemas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieCinemas.Controllers
{
    public class MoviesController : ApiController
    {
        [Route("api/moviecinemas/movies/list")]
        [HttpGet]
        public IHttpActionResult List()
        {
            MoviesService ms = new MoviesService();
            List<MoviesListItem> mli = ms.List();
            return Ok(mli);
        }

        [Route("api/moviecinemas/movies/details/{id}")]
        [HttpGet]
        public IHttpActionResult Details(Guid id)
        {
            MoviesService ms = new MoviesService();
            MoviesForm mf = ms.Details(id);
            return Ok(mf);
        }

        [Route("api/moviecinemas/movies/save")]
        [HttpPost]
        public IHttpActionResult Save(MoviesSave msave)
        {
            MoviesService ms = new MoviesService();
            bool success = ms.Save(msave);
            return Ok(success);
        }
    }
}