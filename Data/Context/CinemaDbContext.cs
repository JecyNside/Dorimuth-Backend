using Dorimuth_Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dorimuth_Backend.Data.Context
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de índices únicos
            modelBuilder.Entity<Reservation>()
                .HasIndex(r => r.TicketNumber)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => new { c.DocumentType, c.DocumentNumber})
                .IsUnique();

            // Configuración de relaciones con eliminación en cascada
            modelBuilder.Entity<Showtime>()
                .HasOne(f => f.Movie)
                .WithMany(p => p.Showtimes)
                .HasForeignKey(f => f.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Showtime>()
                .HasOne(f => f.Room)
                .WithMany(s => s.Showtimes)
                .HasForeignKey(f => f.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Showtime)
                .WithMany(f => f.Reservations)
                .HasForeignKey(r => r.ShowtimeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Datos semilla (opcional)
            //SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Salas
            //modelBuilder.Entity<Room>().HasData(
            //    new Room { Name = "Sala 1", Capacity = 150, Active = true },
            //    new Room { Name = "Sala 2", Capacity = 120, Active = true },
            //    new Room { Name = "Sala 3", Capacity = 200, Active = true },
            //    new Room { Name = "Sala VIP", Capacity = 50, Active = true }
            //);
        }
    }
}
