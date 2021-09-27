using MovieCinemas.DTO;
using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Services
{
    public class ClubCardsService
    {
        public List<ClubCardsListItem> List()
        {
            using (var context = new MovieCinemasDbContext())
            {
                List<ClubCardsListItem> list = context.ClubCards.Select(a => new ClubCardsListItem
                {
                    Id = a.Id,
                    UserName = a.User.Name,
                    DateCreated = a.DateCreated,
                    AdministratorName = a.Administrator.Name,
                    Enabled = a.Enabled,
                }).ToList();
                return list;
            }
        }

        public ClubCardDetails Details(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                ClubCardDetails clubCard = context.ClubCards.Where(a => a.Id == id).Select(a => new ClubCardDetails
                {
                    UserName = a.User.Name,
                    DateCreated = a.DateCreated,
                    AdministratorName = a.Administrator.Name,
                    Points = a.Points,
                    DiscountPercantage = a.DiscountPercantage,
                }).FirstOrDefault();
                return clubCard;
            }
        }

        public bool Save(ClubCardsSave model)
        {
            using (var context = new MovieCinemasDbContext())
            {
                ClubCards card = new ClubCards
                {
                    Id = model.Id,
                    AdministratorId = model.AdministratorId,
                    UserId = model.UserId,
                    DateCreated = DateTime.Now,
                    Points = model.Points,
                    DiscountPercantage = model.DiscountPercantage,
                };

                if (card.Id != Guid.Empty)
                {
                    context.ClubCards.Attach(card);
                    context.Entry(card).Property(a => a.DiscountPercantage).IsModified = true;
                    context.Entry(card).Property(a => a.Points).IsModified = true;
                }
                else
                    context.ClubCards.Add(card);
                context.SaveChanges();
                return true;
            }
        }

        public bool Enable(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                ClubCards card = context.ClubCards.Where(a => a.Id == id).FirstOrDefault();
                if (card == null)
                    return false;
                card.Enabled = !card.Enabled;
                return true;
            }
        }
    }
}