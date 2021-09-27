using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieCinemas.Models
{
    public class ClubCards
    {
        public Guid Id { get; set; }

        [ForeignKey("Administrator")]
        public Guid? AdministratorId { get; set; }
        public Administrators Administrator { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public Users User { get; set; }

        [ForeignKey("FoodPackage")]
        public Guid FoodPackageId { get; set; }
        public FoodPackages FoodPackage { get; set; }

        public DateTime DateCreated { get; set; }
        public double Points { get; set; }
        public bool Enabled { get; set; }
        public double? DiscountPercantage { get; set; }
    }
}