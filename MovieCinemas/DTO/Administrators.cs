using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCinemas.DTO
{
    public class AdministratorsListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public bool Disabled { get; set; }
    }

    public class AdministratorsForm
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
    }

    public class AdministratorsSave
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AdministratorsPermissions
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }

    public class AdministratorsPermissionEnabled
    {
        public Guid AdministratorId { get; set; }
        public Guid PermissionId { get; set; }
    }
}