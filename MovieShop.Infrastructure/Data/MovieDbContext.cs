using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Data
{
    public class MovieDbContext : IdentityDbContext<User>
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {

        }
        public DbSet<Crew> Crew{ get; set; }
        public DbSet<MovieCrew> MovieCrew{ get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Trailer> Trailer { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<User> User { get; set; }
        //public DbSet<Role> Role { get; set; }
        //public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
       
       
    }
}
