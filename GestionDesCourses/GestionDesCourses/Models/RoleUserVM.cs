using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesCourses.Models
{
    public class RoleUserVM
    {
        public ApplicationUserManager applicationUserManager { get; set; }

        public List<UserRole> UserRoles { get; set; }

        public int? IdSelectUserRole { get; set; }
    }
}