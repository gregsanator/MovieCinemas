using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class UsersListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public bool Enabled { get; set; }
    }

    public class UsersForm
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
    }

    public class UsersSave
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public bool Enabled { get; set; }
        public DateTime Birthday { get; set; }
        public Guid AdministratorId { get; set; }
    }
}