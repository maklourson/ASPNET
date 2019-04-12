using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BO;

namespace GestionDesCourses.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ContextGestionCourse", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BO.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<BO.DisplayConfiguration> DisplayConfigurations { get; set; }

        public System.Data.Entity.DbSet<BO.UniteDistance> UniteDistances { get; set; }

        public System.Data.Entity.DbSet<BO.TypeInscription> TypeInscriptions { get; set; }

        public System.Data.Entity.DbSet<BO.UserRole> UserRoles { get; set; }

        public System.Data.Entity.DbSet<BO.Race> Races { get; set; }

        public System.Data.Entity.DbSet<BO.Inscription> Inscriptions { get; set; }

        public System.Data.Entity.DbSet<BO.Poi> Pois { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Race>().HasMany(p => p.Pois).WithMany();
            modelBuilder.Entity<Race>().HasRequired<Category>(c => c.Category)
                .WithMany(r => r.Races);
        }
    }
}