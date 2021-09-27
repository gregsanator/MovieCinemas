using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class ClubCardsListItem
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Enabled { get; set; }
        public string AdministratorName { get; set; }
        public string UserName { get; set; }
    }

    public class ClubCardDetails
    {
        public DateTime DateCreated { get; set; }
        public double Points { get; set; }
        public bool Enabled { get; set; }
        public double? DiscountPercantage { get; set; }
        public string AdministratorName { get; set; }
        public string UserName { get; set; }
    }

    public class ClubCardsSave
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public double Points { get; set; }
        public bool Enabled { get; set; }
        public double? DiscountPercantage { get; set; }
        public Guid AdministratorId { get; set; }
        public Guid UserId { get; set; }
    }
}