using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.DTOs;
using CoVoyageur.Core.Models;
using CoVoyageur.Core.Data;

namespace CoVoyageur.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;

        public DbSet<Ride> Rides { get; set; } = default!;

        public DbSet<Feedback> Feedbacks { get; set; } = default!;

        public DbSet<Reservation> Reservations { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(InitialData.users);
            modelBuilder.Entity<Ride>().HasData(InitialData.rides);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Author)     
                .WithMany()                
                .HasForeignKey(f => f.ID_Passenger)  
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Driver)     
                .WithMany()               
                .HasForeignKey(f => f.ID_Driver)  
                .OnDelete(DeleteBehavior.Restrict);  
        }

    }
}
