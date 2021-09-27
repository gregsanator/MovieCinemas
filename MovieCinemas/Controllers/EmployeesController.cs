using MovieCinemas.DTO;
using MovieCinemas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieCinemas.Controllers
{
    public class EmployeesController : ApiController
    {
        [Route("api/moviecinemas/employees/list")]
        [HttpGet]
        public IHttpActionResult List()
        {
            EmployeesService service = new EmployeesService();
            List<EmployeesListItem> employeesList = service.List();
            return Ok(employeesList);
        }

        [Route("api/moviecinemas/employees/details/{id}")]
        [HttpGet]
        public IHttpActionResult Details(Guid id)
        {
            EmployeesService service = new EmployeesService();
            EmployeesForm employeesDetails = service.Details(id);
            return Ok(employeesDetails);
        }

        [Route("api/moviecinemas/employees/save")]
        [HttpPost]
        public IHttpActionResult Save(EmployeesSave save)
        {
            EmployeesService service = new EmployeesService();
            bool success = service.Save(save);
            return Ok(success);
        }
    }
}