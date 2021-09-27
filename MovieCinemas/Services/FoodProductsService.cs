using MovieCinemas.DTO;
using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Services
{
    public class FoodProductsService
    {
        public List<FoodProductsListItem> List()
        {
            using(var context = new MovieCinemasDbContext())
            {
                List<FoodProductsListItem> list = context.FoodProducts.Select(a => new FoodProductsListItem
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList();
                return list ;
            }
        }

        public FoodProductsForm Details(Guid id)
        {
            using(var context = new MovieCinemasDbContext())
            {
                FoodProductsForm item = context.FoodProducts.Where(a => a.Id == id).Select(a => new FoodProductsForm
                {
                    Name = a.Name,
                    Price = a.Price
                }).FirstOrDefault();
                return item;
            }
        }

        public bool Save(FoodProductsSave model)
        {
            using(var context = new MovieCinemasDbContext())
            {
                FoodProducts product = new FoodProducts
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price
                };

                if (product.Id != Guid.Empty)
                {
                    context.FoodProducts.Attach(product);
                    context.Entry(product).Property(a => a.Name).IsModified = true;
                    context.Entry(product).Property(a => a.Price).IsModified = true;
                }
                else
                    context.FoodProducts.Add(product);
                context.SaveChanges();
                return true;
            }
        }
    }
}