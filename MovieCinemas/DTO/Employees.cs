using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class EmployeesListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string CinemaName { get; set; }
    }

    public class EmployeesForm 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string CinemaName { get; set; }
        public Guid CinemaId { get; set; }
    }

    public class EmployeesSave
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid CinemaId { get; set; }
        public Guid AdministratorId { get; set; }

    }
}