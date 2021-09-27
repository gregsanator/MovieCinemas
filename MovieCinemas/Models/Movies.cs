using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieCinemas.Models
{
    public class Movies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }


        [ForeignKey("CinemaRoom")]
        public Guid CinemaRoomId { get; set; }
        public CinemaRooms CinemaRoom { get; set; }

        [ForeignKey("Administrator")]
        public Guid AdministratorId { get; set; }
        public Administrators Administrator { get; set; }
    }
}