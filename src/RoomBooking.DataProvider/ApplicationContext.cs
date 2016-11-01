using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RoomBooking.Shared.Entities;

namespace RoomBooking.DataProvider
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
            
            modelBuilder.Entity<Hotel>(ConfigureHotel);
            modelBuilder.Entity<Room>(ConfigureRoom);
            modelBuilder.Entity<RoomReservation>(ConfigureRoomReservation);
        }

        private static void ConfigureHotel(EntityTypeBuilder<Hotel> entityBuilder)
        {
            // Hotels
            entityBuilder.HasKey(h => h.Id);
            entityBuilder.Property(h => h.Id).ValueGeneratedOnAdd().IsConcurrencyToken();
            entityBuilder.Property(h => h.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(h => h.Address).HasMaxLength(100);
            entityBuilder.Property(h => h.Country).HasMaxLength(100);
            entityBuilder.HasMany(h => h.Rooms).WithOne(r => r.Hotel);
        }

        private static void ConfigureRoom(EntityTypeBuilder<Room> entityBuilder)
        {
            // Rooms
            entityBuilder.HasKey(r => r.Id);
            entityBuilder.Property(r => r.Id).ValueGeneratedOnAdd().IsConcurrencyToken();
            entityBuilder.Property(r => r.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(r => r.RoomType).IsRequired();
            entityBuilder.HasOne(r => r.Hotel);
        }

        private static void ConfigureRoomReservation(EntityTypeBuilder<RoomReservation> entityBuilder)
        {
            // Room Reservations
            entityBuilder.HasKey(rr => rr.Id);
            entityBuilder.Property(rr => rr.Id).ValueGeneratedOnAdd().IsConcurrencyToken();
            entityBuilder.Property(rr => rr.ClientName).IsRequired().HasMaxLength(150);
            entityBuilder.Property(rr => rr.StartDate).IsRequired();
            entityBuilder.Property(rr => rr.EndDate).IsRequired();
            entityBuilder.HasOne(a => a.Room);
        }
    }
}