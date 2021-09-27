using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class ReservationsListItem
    {
        public Guid Id { get; set; }
        public string MovieName { get; set; }
        public double Price { get; set; }
        public DateTime ReservationDate { get; set; }
        public string CinemaRoom { get; set; }
    }

    public class ReservationFilter
    {
        public Guid? UserId { get; set; }
        public Guid? AdministratorId { get; set; }
    }

    public class ReservationsDetails
    {
        public double Price { get; set; }
        public string MovieName { get; set; }
    }

    public class ReservationsSave
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public Guid? AdministratorId { get; set; }
        public Guid? FoodPackageId { get; set; }
    }
}