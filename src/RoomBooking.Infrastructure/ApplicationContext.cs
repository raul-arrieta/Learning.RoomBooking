using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RoomBooking.Shared.Entities;

namespace RoomBooking.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<Error> Errors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                entity.Relational().TableName = entity.DisplayName();

            ModelHotels(modelBuilder);
            ModelRooms(modelBuilder);
            ModelRoomReservations(modelBuilder);
        }

        protected virtual void ModelHotels(ModelBuilder modelBuilder)
        {
            // Hotels
            modelBuilder.Entity<Hotel>().Property(h => h.Id).IsRequired();
            modelBuilder.Entity<Hotel>().Property(h => h.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Hotel>().Property(h => h.Address).HasMaxLength(100);
            modelBuilder.Entity<Hotel>().Property(h => h.Country).HasMaxLength(100);
            modelBuilder.Entity<Hotel>().HasMany(h => h.Rooms).WithOne(r => r.Hotel);
        }

        protected virtual void ModelRooms(ModelBuilder modelBuilder)
        {
            // Rooms
            modelBuilder.Entity<Room>().Property(r => r.Id).IsRequired();
            modelBuilder.Entity<Room>().Property(r => r.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Room>().Property(r => r.RoomType).IsRequired();
            modelBuilder.Entity<Room>().HasOne(r => r.Hotel);
        }

        protected virtual void ModelRoomReservations(ModelBuilder modelBuilder)
        {
            // Room Reservations
            modelBuilder.Entity<RoomReservation>().Property(rr => rr.Id).IsRequired();
            modelBuilder.Entity<RoomReservation>().Property(rr => rr.ClientName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<RoomReservation>().Property(rr => rr.StartDate).IsRequired();
            modelBuilder.Entity<RoomReservation>().Property(rr => rr.EndDate).IsRequired();
            modelBuilder.Entity<RoomReservation>().HasOne(a => a.Room);
        }
    }
}