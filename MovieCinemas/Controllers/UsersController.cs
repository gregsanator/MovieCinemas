using MovieCinemas.DTO;
using MovieCinemas.Models;
using MovieCinemas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieCinemas.Controllers
{
    public class UsersController : ApiController
    {
        [Route("api/moviecinemas/users/list")]
        [HttpGet]
        public IHttpActionResult List()
        {
            UsersService service = new UsersService();
            List<UsersListItem> list = service.List();
            return Ok();
        }
        
        [Route("api/moviecinemas/users/details/{id}")]
        [HttpGet]
        public IHttpActionResult List(Guid id)
        {
            UsersService service = new UsersService();
            UsersForm user = service.Details(id);
            return Ok(user);
        }
        
        [Route("api/moviecinemas/users/save")]
        [HttpPost]
        public IHttpActionResult Save(UsersSave model)
        {
            UsersService service = new UsersService();
            bool user = service.Save(model);
            return Ok(user);
        }

        [Route("api/moviecinemas/users/enable")]
        [HttpPost]
        public IHttpActionResult Enable(Guid id)
        {
            UsersService service = new UsersService();
            bool user = service.Enable(id);
            return Ok(user);
        }
    }
}