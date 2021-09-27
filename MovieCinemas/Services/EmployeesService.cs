using MovieCinemas.DTO;
using MovieCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.Services
{
    public class EmployeesService
    {
        public List<EmployeesListItem> List()
        {
            using(var context = new MovieCinemasDbContext())
            {
                return context.Employees.Select(a => new EmployeesListItem
                {
                    Id = a.Id,
                    Name = a.Name,
                    Surname = a.Surname,
                    BirthDate = a.BirthDate,
                    CinemaName = a.Cinema.Name,
                }).ToList();
            }
        }

        public EmployeesForm Details(Guid id)
        {
            using(var context = new MovieCinemasDbContext())
            {
               return context.Employees.Where(a => a.Id == id).Select(a => new EmployeesForm
                {
                    Name = a.Name,
                    Surname = a.Surname,
                    BirthDate = a.BirthDate,
                    CinemaName = a.Cinema.Name
                }).FirstOrDefault();
            }
        }

        public bool Save(EmployeesSave save)
        {
            using(var context = new MovieCinemasDbContext())
            {
                Employees employees = new Employees
                {
                    Id = save.Id,
                    Name = save.Name,
                    Surname = save.Surname,
                    BirthDate = save.BirthDate,
                    CinemaId = save.CinemaId,
                    AdministratorId = save.AdministratorId
                };
                if (Guid.Empty != employees.Id)
                {
                    context.Employees.Attach(employees);
                    context.Entry(employees).Property(a => a.Name).IsModified = true;
                    context.Entry(employees).Property(a => a.Surname).IsModified = true;
                    context.Entry(employees).Property(a => a.BirthDate).IsModified = true;
                    context.Entry(employees).Property(a => a.CinemaId).IsModified = true;
                }
                else
                {
                    context.Employees.Add(employees);
                }
                context.SaveChanges();
                return true;
            }
        }
    }
}