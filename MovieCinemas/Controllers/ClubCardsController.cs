using MovieCinemas.DTO;
using MovieCinemas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieCinemas.Controllers
{
    public class ClubCardsController : ApiController
    {
        [Route("api/moviecinemas/clubcards/list")]
        [HttpGet]
        public IHttpActionResult List()
        {
            ClubCardsService service = new ClubCardsService();
            List<ClubCardsListItem> list = service.List();
            return Ok(list);
        }

        [Route("api/moviecinemas/clubcards/details/{id}")]
        [HttpGet]
        public IHttpActionResult Details(Guid id)
        {
            ClubCardsService service = new ClubCardsService();
            ClubCardDetails details = service.Details(id);
            return Ok(details);
        }

        [Route("api/moviecinemas/clubcards/save")]
        [HttpPost]
        public IHttpActionResult Save(ClubCardsSave model)
        {
            ClubCardsService service = new ClubCardsService();
            bool changes = service.Save(model);
            return Ok(changes);
        }

        [Route("api/moviecinemas/clubcards/enable")]
        [HttpPost]
        public IHttpActionResult Enable(Guid id)
        {
            ClubCardsService service = new ClubCardsService();
            bool enable = service.Enable(id);
            return Ok(enable);
        }
    }
}