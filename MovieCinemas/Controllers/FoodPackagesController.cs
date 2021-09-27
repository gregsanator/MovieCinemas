using MovieCinemas.DTO;
using MovieCinemas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieCinemas.Controllers
{
    public class FoodPackagesController : ApiController
    {
        [HttpGet]
        [Route("api/moviecinemas/foodpackages/list")]
        public IHttpActionResult List()
        {
            FoodPackagesService service = new FoodPackagesService();
            List<FoodPackagesListItem> list = service.List();
            return Ok(list);
        }

        [HttpGet]
        [Route("api/moviecinemas/foodpackages/details/{id}")]
        public IHttpActionResult Details(Guid id)
        {
            FoodPackagesService service = new FoodPackagesService();
            FoodPackagesDetails details = service.Details(id);
            return Ok(details);
        }

        [HttpPost]
        [Route("api/moviecinemas/foodpackages/save")]
        public IHttpActionResult Save(FoodPackagesSave model)
        {
            FoodPackagesService service = new FoodPackagesService();
            bool save = service.Save(model);
            return Ok(save);
        }

        [HttpGet]
        [Route("api/moviecinemas/foodpackages/productsinpackages/{id}")]
        public IHttpActionResult ProductsInPackage(Guid id)
        {
            FoodPackagesService service = new FoodPackagesService();
            List<ProductInPackage> productList = service.ProductsInPackage(id);
            return Ok(productList);
        }

        [HttpPost]
        [Route("api/moviecinemas/foodpackages/enablefoodproduct")]
        public IHttpActionResult AddProductToPackage(EnableProductInPackage model)
        {
            FoodPackagesService service = new FoodPackagesService();
            bool enabled = service.AddProductToPackage(model);
            return Ok(enabled);
        }
    }
}