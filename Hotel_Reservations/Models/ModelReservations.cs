namespace Reservations
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelReservations : DbContext
    {
        public ModelReservations()
            : base("name=ModelReservations")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CreditCardType> CreditCardTypes { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<ReservedRoom> ReservedRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(e => e.country1)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.postalPattern)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Regions)
                .WithRequired(e => e.Country1)
                .HasForeignKey(e => e.country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Country1)
                .HasForeignKey(e => e.country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CreditCardType>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<CreditCardType>()
                .Property(e => e.cardNumberPattern)
                .IsUnicode(false);

            modelBuilder.Entity<CreditCardType>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.CreditCardType1)
                .HasForeignKey(e => e.CreditCardType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.region1)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Region1)
                .HasForeignKey(e => e.region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.streetNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.streetName)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.postalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.emailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.nameOnTheCard)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.CreditCardnumber)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.roomNumber)
                .IsUnicode(false);

            modelBuilder.Entity<RoomType>()
                .Property(e => e.roomType1)
                .IsUnicode(false);

            modelBuilder.Entity<RoomType>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.RoomType1)
                .HasForeignKey(e => e.roomType)
                .WillCascadeOnDelete(false);
        }
    }
}
