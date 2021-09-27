using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class FoodPackagesListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }

    public class FoodProductsInPackage
    {
        public string ProductName { get; set; }
    }

    public class FoodPackagesDetails
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int NumberOfProducts { get; set; }
        public List<FoodProductsInPackage> ProductList { get; set; }
    }

    public class FoodPackagesSave
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
    }

    public class ProductInPackage
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public bool Enabled { get; set; }
    }

    public class EnableProductInPackage
    {
        public Guid FoodPackageId { get; set; }
        public Guid FoodProducteId { get; set; }
    }

}