namespace GestionDesCourses.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GestionDesCourses.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GestionDesCourses.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if(!context.Roles.Any(r => r.Name == "SA"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "SA" };
                var role1 = new IdentityRole { Name = "Admin" };
                var role2 = new IdentityRole { Name = "user" };

                manager.Create(role);
                manager.Create(role1);
                manager.Create(role2);
            }

            if (!context.Users.Any(u => u.UserName == "SA"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var SA = new ApplicationUser { UserName = "SA",FirstName = "SuperAdmin", LastName ="SuperAdmin" };
                var Admin = new ApplicationUser { UserName = "Admin", FirstName = "Admin", LastName = "Admin" };
                var user = new ApplicationUser { UserName = "User", FirstName = "User", LastName = "User" };

                manager.Create(SA, "Pa$$w0rd!");
                manager.AddToRole(SA.Id, "SA");

                manager.Create(Admin, "admin1234!");
                manager.AddToRole(Admin.Id, "Admin");

                manager.Create(user, "user1234!");
                manager.AddToRole(user.Id, "user");
            }

            context.Categories.AddOrUpdate(
                c => c.Title,
                new BO.Category { Title = "Velo"},
                new BO.Category { Title = "Moto" },
                new BO.Category { Title = "Roller" },
                new BO.Category { Title = "Trotinette" },
                new BO.Category { Title = "A pied" }
                );
        }
    }
}
