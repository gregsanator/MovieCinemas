using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieCinemas.Models
{
    public class Reservations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime ReservationDate { get; set; }

        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movies Movie { get; set; }

        [ForeignKey("Administrator")]
        public Guid? AdministratorId { get; set; }
        public Administrators Administrator { get; set; }
        
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public Users User { get; set; }

        [ForeignKey("FoodPackage")]
        public Guid FoodPackageId { get; set; }
        public FoodPackages FoodPackage { get; set; }

    }
}