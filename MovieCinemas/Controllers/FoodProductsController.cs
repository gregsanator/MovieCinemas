using MovieCinemas.DTO;
using MovieCinemas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieCinemas.Controllers
{
    public class FoodProductsController : ApiController
    {
        [HttpGet]
        [Route("api/moviecinemas/foodproducts/list")]
        public IHttpActionResult List()
        {
            FoodProductsService service = new FoodProductsService();
            List<FoodProductsListItem> list = service.List();
            return Ok(list);
        }

        [HttpGet]
        [Route("api/moviecinemas/foodproducts/list/{id}")]
        public IHttpActionResult Details(Guid id)
        {
            FoodProductsService service = new FoodProductsService();
            FoodProductsForm product = service.Details(id);
            return Ok(product);
        }

        [HttpPost]
        [Route("api/moviecinemas/foodproducts/save")]
        public IHttpActionResult Save(FoodProductsSave model)
        {
            FoodProductsService service = new FoodProductsService();
            bool save = service.Save(model);
            return Ok(save);
        }


    }
}