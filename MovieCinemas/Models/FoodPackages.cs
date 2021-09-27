using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Models
{
    public class FoodPackages
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
    }
}