using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class CinemasList 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Enabled { get; set; }
    }

    public class CinemasDetails
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Enabled { get; set; }
    }

    public class CinemasSave
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Enabled { get; set; }
        public Guid AdministratorId { get; set; }

    }
}