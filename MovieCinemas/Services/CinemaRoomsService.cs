using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MovieCinemas.DTO.CinemaRooms;

namespace MovieCinemas.Services
{
    public class CinemaRoomsService
    {
        public List<CinemaRoomsList> List()
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.CinemaRooms.Select(cr => new CinemaRoomsList
                {
                    Id = cr.Id,
                    Name = cr.Name,
                    NumberOfSeats = cr.NumberOfSeats,
                    CinemaName = cr.Cinema.Name
                }).ToList();
            }
        }

        public CinemaRoomsDetails Details(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.CinemaRooms.Where(a => a.Id == id).Select(cr => new CinemaRoomsDetails
                {
                    Name = cr.Name,
                    NumberOfSeats = cr.NumberOfSeats,
                    Enabled = cr.Enabled,
                    CinemaId = cr.CinemaId
                }).FirstOrDefault();
            }
        }

        public bool Save(CinemaRoomsSave save)
        {
            using (var context = new MovieCinemasDbContext())
            {
                CinemaRooms room = new CinemaRooms
                {
                    Id = save.Id,
                    Name = save.Name,
                    NumberOfSeats = save.NumberOfSeats,
                    Enabled = save.Enabled,
                    CinemaId = save.CinemaId,
                    AdministratorId = save.AdministratorId
                };
                if(room.Id != Guid.Empty)
                {
                    context.CinemaRooms.Attach(room);
                    context.Entry(room).Property(p => p.Name).IsModified = true;
                    context.Entry(room).Property(p => p.NumberOfSeats).IsModified = true;
                    context.Entry(room).Property(p => p.Enabled).IsModified = true;
                    context.Entry(room).Property(p => p.CinemaId).IsModified = true;
                }
                else
                {
                    context.CinemaRooms.Add(room);
                }
                context.SaveChanges();
                return true;
            }
        }
    }
}