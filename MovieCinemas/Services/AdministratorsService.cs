using MovieCinemas.DTO;
using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Services
{
    public class AdministratorsService
    {
        public List<AdministratorsListItem> List()
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.Administrators.Select(a => new AdministratorsListItem
                {
                    Id = a.Id,
                    Name = a.Name,
                    Surname = a.Surname,
                    Username = a.Username,
                    Disabled = a.Disabled
                }).ToList();
            }
        }

        public AdministratorsForm Details(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                return context.Administrators.Where(a => a.Id == id).Select(a => new AdministratorsForm
                {
                    Name = a.Name,
                    Surname = a.Surname,
                    Username = a.Username
                }).FirstOrDefault();
            }
        }

        public bool Save(AdministratorsSave save)
        {
            using (var context = new MovieCinemasDbContext())
            {
                Administrators admin = new Administrators
                {
                    Id = save.Id,
                    Username = save.Username,
                    Password = save.Password,
                    Name = save.Name,
                    Surname = save.Surname,
                };
                if (admin.Id != Guid.Empty)
                {
                    context.Administrators.Attach(admin);
                    context.Entry(admin).Property(a => a.Username).IsModified = true;
                    context.Entry(admin).Property(a => a.Password).IsModified = true;
                    context.Entry(admin).Property(a => a.Name).IsModified = true;
                    context.Entry(admin).Property(a => a.Surname).IsModified = true;
                }
                else
                    context.Administrators.Add(admin);
                context.SaveChanges();
                return true;
            }
        }

        public bool Enabled(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                Administrators admin = context.Administrators.Where(a => a.Id == id).FirstOrDefault();
                if (admin == null)
                    return false;
                admin.Disabled = !admin.Disabled;
                return true;
            }
        }

        public List<AdministratorsPermissions> Permissions(Guid id)
        {
            using (var context = new MovieCinemasDbContext())
            {
                List<AdministratorsPermissions> joined = (from p in context.Permissions
                                                          join ap in context.AdministratorPermissions.Where(a => a.AdministratorId == id)
                                                          on p.Id equals ap.PermissionId into joinedpap
                                                          from pap in joinedpap.DefaultIfEmpty()
                                                          select new AdministratorsPermissions
                                                          {
                                                              Id = p.Id,
                                                              Name = p.Name,
                                                              Enabled = pap != null
                                                          }).ToList();
                return joined;
            }
        }

        public bool AdministratorsPermissionEnabled(AdministratorsPermissionEnabled model)
        {
            using (var context = new MovieCinemasDbContext())
            {
                AdministratorPermissions administratorPermission = context.AdministratorPermissions.Where(a => a.PermissionId == model.PermissionId &&
                a.AdministratorId == model.AdministratorId).FirstOrDefault();
                if (administratorPermission == null)
                {
                    AdministratorPermissions aPermission = new AdministratorPermissions()
                    {
                        AdministratorId = model.AdministratorId,
                        PermissionId = model.PermissionId
                    };
                    context.AdministratorPermissions.Add(aPermission);
                }
                else
                    context.AdministratorPermissions.Remove(administratorPermission);
                context.SaveChanges();
                return true;
            }
        }
    }
}