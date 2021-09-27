using MovieCinemas.DTO;
using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Services
{
    public class ReservationsService
    {
        public List<ReservationsListItem> List(ReservationFilter filter)
        {
            using (var context = new MovieCinemasDbContext())
            {
                IQueryable<Reservations> reservations = context.Reservations;
                if (filter.AdministratorId.HasValue)
                    reservations = reservations.Where(a => a.AdministratorId == filter.AdministratorId.Value);
                else
                    reservations = reservations.Where(a => a.UserId == filter.UserId.Value);
               
                List<ReservationsListItem> list = reservations.Select(a => new ReservationsListItem
                {
                    Id = a.Id,
                    MovieName = a.Movie.Name,
                    Price = a.Price,
                    ReservationDate = a.ReservationDate,
                    CinemaRoom = a.Movie.CinemaRoom.Name
                }).ToList();
                return list;
            }
        }

        public ReservationsDetails Details(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.Reservations.Where(a => a.Id == id).Select(a => new ReservationsDetails
                {
                    Price = a.Price,
                    MovieName = a.Movie.Name
                }).FirstOrDefault();
            }
        }

        public bool Save(ReservationsSave save)
        {
            using (var context = new MovieCinemasDbContext())
            {
                double? discountPercantage = context.ClubCards.Where(a => a.UserId == save.UserId).Select(a => a.DiscountPercantage).FirstOrDefault();
                if (discountPercantage.HasValue)
                    save.Price -= save.Price / 100 * discountPercantage.Value; 

                Reservations reservation = new Reservations
                {
                    Id = save.Id,
                    Price = save.Price,
                    MovieId = save.MovieId,
                    UserId = save.UserId,
                    AdministratorId = save.AdministratorId,
                    ReservationDate = DateTime.Now
                };
                if (reservation.Id != Guid.Empty)
                {
                    context.Reservations.Attach(reservation);
                    context.Entry(reservation).Property(a => a.Price).IsModified = true;
                    context.Entry(reservation).Property(a => a.MovieId).IsModified = true;
                    context.Entry(reservation).Property(a => a.UserId).IsModified = true;
                    context.Entry(reservation).Property(a => a.ReservationDate).IsModified = true;
                    context.Entry(reservation).Property(a => a.AdministratorId).IsModified = true;
                }
                else
                    context.Reservations.Add(reservation);
                context.SaveChanges();
                return true;
            }
        }
    }
}