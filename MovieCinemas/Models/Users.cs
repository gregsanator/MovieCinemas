using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieCinemas.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string UserName { get; set; }
        public bool Enabled { get; set; }

        [ForeignKey("Administrator")]
        public Guid AdministratorId { get; set; }
        public Administrators Administrator { get; set; }

    }
}