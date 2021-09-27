using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieCinemas.Models
{
    public class MovieCinemasDbContext : DbContext
    {
        public MovieCinemasDbContext() : base("name=MovieCinemasDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Cinemas>()
                .HasRequired(c => c.Administrator)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasRequired(c => c.Administrator)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movies>()
                .HasRequired(c => c.Administrator)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Cinemas> Cinemas { get; set; }
        public DbSet<CinemaRooms> CinemaRooms { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Administrators> Administrators { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<AdministratorPermissions> AdministratorPermissions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ClubCards> ClubCards { get; set; }
        public DbSet<FoodProducts> FoodProducts { get; set; }
        public DbSet<FoodPackages> FoodPackages { get; set; }
        public DbSet<FoodProductsFoodPackages> FoodProductsFoodPackages { get; set; }
    }
}