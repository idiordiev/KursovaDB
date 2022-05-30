using KursovaDB.DAL.Entities;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursovaDB.DAL.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citizen> Citizen { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestStatus> RequestStatus { get; set; }
        public virtual DbSet<SocialService> SocialService { get; set; }
        public virtual DbSet<Specialist> Specialist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=KursovaDB;Integrated Security=true;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.Property(e => e.AddressOfResidence).HasMaxLength(100);

                entity.Property(e => e.CityOfResidence).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.RequestDescription).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.CitizenId)
                    .HasConstraintName("FK_CitizenId");

                entity.HasOne(d => d.Specialist)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.SpecialistId)
                    .HasConstraintName("FK_SpecialistId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_StatusId");
            });

            modelBuilder.Entity<RequestStatus>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<SocialService>(entity =>
            {
                entity.Property(e => e.ServiceDescription).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Specialist>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Specialization).HasMaxLength(100);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Specialist)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_ServiceId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
