using MovieCinemas.DTO;
using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Services
{
    public class CinemasService
    {
        public List<CinemasList> List()
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.Cinemas.Select(c => new CinemasList()
                {
                    Id = c.Id, // prasaj
                    Name = c.Name,
                    Location = c.Location,
                    Enabled = c.Enabled
                }).ToList();
            }
        }

        public CinemasDetails Details(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.Cinemas.Where(a => a.Id == id).Select(c => new CinemasDetails()
                {
                    Name = c.Name,
                    Location = c.Location,
                    Enabled = c.Enabled
                }).FirstOrDefault();
            }
        }

        public bool Save(CinemasSave save)
        {
            using (var context = new MovieCinemasDbContext())
            {
                Cinemas cinema = new Cinemas
                {
                    Id = save.Id,
                    Name = save.Name,
                    Location = save.Location,
                    Enabled = save.Enabled,
                    AdministratorId = save.AdministratorId
                };

                if (cinema.Id != Guid.Empty)
                {
                    context.Cinemas.Attach(cinema);
                    context.Entry(cinema).Property(c => c.Name).IsModified = true; ;
                    context.Entry(cinema).Property(c => c.Location).IsModified = true;
                    context.Entry(cinema).Property(c => c.Enabled).IsModified = true;
                }
                else
                {
                    context.Cinemas.Add(cinema);
                }
                context.SaveChanges();
                return true;
            }
        }

        public bool Enable(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                Cinemas cinema = context.Cinemas.Where(a => a.Id == id).FirstOrDefault();
                if (cinema != null)
                {
                    return false;
                }
                cinema.Enabled = !cinema.Enabled;
                return true;
            }
        }
    }
}