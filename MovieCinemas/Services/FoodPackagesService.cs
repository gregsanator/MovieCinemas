using MovieCinemas.DTO;
using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Services
{
    public class FoodPackagesService
    {
        public List<FoodPackagesListItem> List()
        {
            using (var context = new MovieCinemasDbContext())
            {
                List<FoodPackagesListItem> list = context.FoodPackages.Select(a => new FoodPackagesListItem
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList();
                return list;
            }
        }

        public FoodPackagesDetails Details(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                var join = (from p in context.FoodProducts
                            join pp in context.FoodProductsFoodPackages.Where(a => a.FoodPackageId == id)
                            on p.Id equals pp.FoodProductId
                            join pr in context.FoodPackages on pp.FoodPackageId equals pr.Id
                            select new FoodProductsInPackage
                            {
                                ProductName = p.Name
                            }).ToList();

                FoodPackages package = context.FoodPackages.Where(a => a.Id == id).FirstOrDefault();
                FoodPackagesDetails details = new FoodPackagesDetails
                {
                    Name = package.Name,
                    Price = package.Price.Value,
                    ProductList = join.ToList(),
                    NumberOfProducts = join.ToList().Count
                };
                return details;
            }
        }

        public bool Save(FoodPackagesSave model)
        {
            using (var context = new MovieCinemasDbContext())
            {
                FoodPackages package = new FoodPackages()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price
                };

                if (package.Id != Guid.Empty)
                {
                    context.FoodPackages.Attach(package);
                    context.Entry(package).Property(a => a.Name).IsModified = true;
                    context.Entry(package).Property(a => a.Price).IsModified = true;
                }
                else
                    context.FoodPackages.Attach(package);
                context.SaveChanges();
                return true;
            }
        }
        public List<ProductInPackage> ProductsInPackage(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                List<ProductInPackage> join = (from p in context.FoodProducts
                                               join pp in context.FoodProductsFoodPackages
                                               on p.Id equals pp.FoodProductId into joinedppp
                                               from ppp in joinedppp.DefaultIfEmpty()
                                               select new ProductInPackage
                                               {
                                                   Id = p.Id,
                                                   ProductName = p.Name,
                                                   Enabled = ppp != null
                                               }).ToList();
                return join;
            }
        }

        public bool AddProductToPackage(EnableProductInPackage model)
        {
            using (var context = new MovieCinemasDbContext())
            {
                var p = context.FoodProductsFoodPackages.Where(a => a.FoodPackageId == model.FoodPackageId &&
                a.FoodProductId == model.FoodProducteId).FirstOrDefault();

                if (p != null)
                    context.FoodProductsFoodPackages.Remove(p);
                else
                {
                    FoodProductsFoodPackages newFood = new FoodProductsFoodPackages
                    {
                        FoodPackageId = model.FoodPackageId,
                        FoodProductId = model.FoodProducteId
                    };

                    context.FoodProductsFoodPackages.Add(newFood);

                }
                context.SaveChanges();
                return true;
            }
        }
    }
}