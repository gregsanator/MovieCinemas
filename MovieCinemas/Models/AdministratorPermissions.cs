using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieCinemas.Models
{
    public class AdministratorPermissions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Administrator")]
        public Guid AdministratorId { get; set; }
        public Administrators Administrator { get; set; }

        [ForeignKey("Permission")]
        public Guid PermissionId { get; set; }
        public Permissions Permission { get; set; }
    }
}