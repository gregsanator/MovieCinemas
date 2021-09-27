using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieCinemas.Models
{
    public class CinemaRooms
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
        public bool Enabled { get; set; }

        [ForeignKey("Cinema")]
        public Guid CinemaId { get; set; }
        public Cinemas Cinema { get; set; }

        [ForeignKey("Administrator")]
        public Guid AdministratorId { get; set; }
        public Administrators Administrator { get; set; }
    }
}