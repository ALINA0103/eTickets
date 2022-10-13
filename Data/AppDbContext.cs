using eTickets.Controllers;
using eTickets.Data.ViewModel;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            //modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);

            //modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

            //base.OnModelCreating(modelBuilder);
        }

       
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCartModel { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogins> UserLogin { get; set; }
        
    }
}
