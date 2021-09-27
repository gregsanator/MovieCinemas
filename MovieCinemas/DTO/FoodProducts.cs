using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class FoodProductsListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class FoodProductsForm
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class FoodProductsSave
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}