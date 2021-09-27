using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class MoviesListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public string CinemaRoomName { get; set; }
    }

    public class MoviesForm
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public Guid CinemaRoomId { get; set; }
    }

    public class MoviesSave
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public Guid CinemaRoomId { get; set; }
        public Guid AdministratorId { get; set; }


    }


}