using AdventuraClick.Model;
using Microsoft.EntityFrameworkCore;

namespace AdventuraClick.Service.Database
{
    public partial class AdventuraClickInitContext : DbContext
    {
        public AdventuraClickInitContext()
        {
        }

        public AdventuraClickInitContext(DbContextOptions<AdventuraClickInitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalService> AdditionalServices { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Travel> Travels { get; set; }

        public virtual DbSet<TravelType> TravelTypes { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=adventuraClickInit;user=sa;TrustServerCertificate=true;Trusted_Connection=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalService>(entity =>
            {
                entity.HasKey(e => e.AddServiceId).HasName("PK_9");

                entity.ToTable("AdditionalService");

                entity.Property(e => e.AddServiceId).HasColumnName("addServiceId");
                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");
                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationId).HasName("PK_7");

                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("locationId");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId).HasName("PK_6");

                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");
                entity.Property(e => e.TravelId).HasColumnName("travelId");

                entity.HasOne(d => d.Travel).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.TravelId)
                    .HasConstraintName("FK_REFERENCE_5");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RatingId).HasName("PK_3");

                entity.ToTable("Rating");

                entity.Property(e => e.RatingId).HasColumnName("ratingId");
                entity.Property(e => e.TravelId).HasColumnName("travelId");

                entity.HasOne(d => d.Travel).WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.TravelId)
                    .HasConstraintName("FK_REFERENCE_2");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.ReservationId).HasName("PK_4");

                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId).HasColumnName("reservationId");
                entity.Property(e => e.Date)
                    .HasMaxLength(40)
                    .HasColumnName("date");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.TravelId).HasColumnName("travelId");

                entity.HasOne(d => d.Travel).WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.TravelId)
                    .HasConstraintName("FK_REFERENCE_8");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PK_2");

                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("roleId");
                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Travel>(entity =>
            {
                entity.HasKey(e => e.TravelId).HasName("PK_5");

                entity.ToTable("Travel");

                entity.Property(e => e.TravelId).HasColumnName("travelId");
                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Image).HasColumnName("image");
                entity.Property(e => e.LocationId).HasColumnName("locationId");
                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .HasColumnName("status");
                entity.Property(e => e.TravelTypeId).HasColumnName("travelTypeId");

                entity.HasOne(d => d.TravelType).WithMany(p => p.Travels)
                    .HasForeignKey(d => d.TravelTypeId)
                    .HasConstraintName("FK_REFERENCE_3");
            });

            modelBuilder.Entity<TravelType>(entity =>
            {
                entity.HasKey(e => e.TravelTypeId).HasName("PK_8");

                entity.ToTable("TravelType");

                entity.Property(e => e.TravelTypeId).HasColumnName("travelTypeId");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK_1");

                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("userId");
                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(40)
                    .HasColumnName("createdAt");
                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfBirth");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .HasColumnName("firstName");
                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .HasColumnName("lastName");
                entity.Property(e => e.PasswordHash).HasColumnName("passwordHash");
                entity.Property(e => e.PasswordSalt).HasColumnName("passwordSalt");
                entity.Property(e => e.RoleId).HasColumnName("roleId");
                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_REFERENCE_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}