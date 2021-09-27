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
    public class AdministratorsController : ApiController
    {
        [Route("api/moviecinemas/administrators/list")]
        [HttpPost]
        public IHttpActionResult List()
        {
            AdministratorsService service = new AdministratorsService();
            List<AdministratorsListItem> list = service.List();
            return Ok(list);
        }

        [Route("api/moviecinemas/administrators/details/{id}")]
        [HttpGet]
        public IHttpActionResult Details(Guid id)
        {
            AdministratorsService service = new AdministratorsService();
            AdministratorsForm details = service.Details(id);
            return Ok(details);
        }

        [Route("api/moviecinemas/administrators/save")]
        [HttpPost]
        public IHttpActionResult Save(AdministratorsSave save)
        {
            AdministratorsService service = new AdministratorsService();
            bool success = service.Save(save);
            return Ok(success);
        }

        [Route("api/moviecinemas/administrators/enabled/{id}")]
        [HttpGet]
        public IHttpActionResult Enabled(Guid id)
        {
            AdministratorsService service = new AdministratorsService();
            bool enabled = service.Enabled(id);
            return Ok(enabled);
        }

        [Route("api/moviecinemas/administrators/permissions/{id}")]
        [HttpGet]
        public IHttpActionResult Permissions(Guid id)
        {
            AdministratorsService service = new AdministratorsService();
            List<AdministratorsPermissions> permissions = service.Permissions(id);
            return Ok(permissions);
        }

        [Route("api/moviecinemas/administrators/enablepermission")]
        [HttpPost]
        public IHttpActionResult EnablePermission(AdministratorsPermissionEnabled model)
        {
            AdministratorsService service = new AdministratorsService();
            bool aPermission = service.AdministratorsPermissionEnabled(model);
            return Ok(aPermission);
        }
    }
}