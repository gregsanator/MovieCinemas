using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieCinemas.Models
{
    public class FoodProductsFoodPackages
    {
        public Guid Id { get; set; }
        
        [ForeignKey("FoodProduct")]
        public Guid FoodProductId { get; set; }
        public FoodProducts FoodProduct { get; set; }

        [ForeignKey("FoodPackage")]
        public Guid FoodPackageId { get; set; }
        public FoodPackages FoodPackage { get; set; }
    }
}