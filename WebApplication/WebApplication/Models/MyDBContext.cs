using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.Models
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<ShareBooking> ShareBooking { get; set; }
        public virtual DbSet<ShareTrip> ShareTrip { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TechWiz2;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.IdDriver).HasColumnName("id_driver");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IsCancel).HasColumnName("isCancel");

                entity.Property(e => e.Member).HasColumnName("member");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdDriverNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.IdDriver)
                    .HasConstraintName("FK__Booking__id_driv__4D94879B");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Booking__member__4CA06362");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdCar).HasColumnName("Id_Car");

                entity.Property(e => e.IdProof).HasColumnName("id_proof");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.IdCar)
                    .HasConstraintName("FK__Driver__Id_Car__440B1D61");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Feedback__descri__46E78A0C");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Notificat__id_us__49C3F6B7");
            });

            modelBuilder.Entity<ShareBooking>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.IdSharetrip).HasColumnName("id_sharetrip");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.ShareBooking)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__ShareBook__booki__5165187F");

                entity.HasOne(d => d.IdSharetripNavigation)
                    .WithMany(p => p.ShareBooking)
                    .HasForeignKey(d => d.IdSharetrip)
                    .HasConstraintName("FK_ShareBooking_ShareTrip");
            });

            modelBuilder.Entity<ShareTrip>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SubAmount).HasColumnName("sub_amount");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.IdPoof).HasColumnName("id_poof");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasColumnName("user_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
