using MovieCinemas.DTO;
using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Services
{
    public class MoviesService
    {
        public List<MoviesListItem> List()
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.Movies.Select(m => new MoviesListItem
                {
                    Id = m.Id,
                    Name = m.Name,
                    StartTime = m.StartTime,
                    CinemaRoomName = m.CinemaRoom.Name
                }).ToList();
            }
        }

        public MoviesForm Details(Guid id)
        {

            using (var context = new MovieCinemasDbContext())
            {
                return context.Movies.Where(a => a.Id == id).Select(m => new MoviesForm
                {
                    Name = m.Name,
                    StartTime = m.StartTime,
                    CinemaRoomId = m.CinemaRoomId
                }).FirstOrDefault();
            }
        }

        public bool Save(MoviesSave save)
        {
            using (var context = new MovieCinemasDbContext())
            {
                Movies movie = new Movies
                {
                    Id = save.Id,
                    Name = save.Name,
                    StartTime = save.StartTime,
                    CinemaRoomId = save.CinemaRoomId,
                    AdministratorId = save.AdministratorId
                };

                if(movie.Id != Guid.Empty)
                {
                    context.Movies.Attach(movie);
                    context.Entry(movie).Property(a => a.Name).IsModified = true;
                    context.Entry(movie).Property(a => a.StartTime).IsModified = true;
                    context.Entry(movie).Property(a => a.CinemaRoomId).IsModified = true;
                }
                else
                {
                    context.Movies.Add(movie);
                }
                context.SaveChanges();
                return true;
            }
        }
    }
}