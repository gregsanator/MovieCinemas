using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class CinemaRooms
    {
        public class CinemaRoomsList
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int NumberOfSeats { get; set; }
            public bool Enabled { get; set; }
            public string CinemaName { get; set; }
        }

        public class CinemaRoomsDetails
        {
            public string Name { get; set; }
            public int NumberOfSeats { get; set; }
            public bool Enabled { get; set; }
            public Guid CinemaId { get; set; }
        }

        public class CinemaRoomsSave
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int NumberOfSeats { get; set; }
            public bool Enabled { get; set; }
            public Guid CinemaId { get; set; }
            public Guid AdministratorId { get; set; }
        }
    }
}