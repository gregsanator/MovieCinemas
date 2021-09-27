using MovieCinemas.DTO;
using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Services
{
    public class UsersService
    {
        public List<UsersListItem> List()
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.Users.Select(a => new UsersListItem
                {
                    Id = a.Id,
                    Name = a.Name,
                    Surname = a.Surname,
                    UserName = a.UserName,
                    Enabled = a.Enabled
                }).ToList();
            }
        }

        public UsersForm Details(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.Users.Where(a => a.Id == id).Select(a => new UsersForm
                {
                    Name = a.Name,
                    Birthday = a.Birthday,
                    Surname = a.Surname,
                    UserName = a.UserName
                }).FirstOrDefault();
            }
        }

        public bool Save(UsersSave model)
        {
            using (var context = new MovieCinemasDbContext())
            {
                Users user = new Users
                {
                    Id = model.Id,
                    Name = model.Name,
                    Birthday = model.Birthday,
                    Enabled = true,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    AdministratorId = model.AdministratorId
                };

                if (user.Id != Guid.Empty)
                {
                    context.Users.Attach(user);
                    context.Entry(user).Property(a => a.Name).IsModified = true;
                    context.Entry(user).Property(a => a.Surname).IsModified = true;
                    context.Entry(user).Property(a => a.UserName).IsModified = true;
                    context.Entry(user).Property(a => a.Birthday).IsModified = true;
                }
                else
                    context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
        }

        public bool Enable(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                Users user = context.Users.Where(a => a.Id == id).FirstOrDefault();
                if (user == null)
                    return false;
                user.Enabled = !user.Enabled;
                return true;
            }
        }
    }
}