using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RkisWPFMVVM
{
    public partial class Rkis28WPFContext : DbContext
    {
        public Rkis28WPFContext()
        {
        }

        public Rkis28WPFContext(DbContextOptions<Rkis28WPFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StatusTabl> StatusTabl { get; set; } = null!;
        public virtual DbSet<Tasks> Tasks { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Rkis28WPF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusTabl>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("StatusTabl");

                entity.Property(e => e.IdStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("idStatus");

                entity.Property(e => e.NameStatus).HasMaxLength(50);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.IdTask);

                entity.Property(e => e.IdTask).HasColumnName("idTask");

                entity.Property(e => e.DatePubl).HasColumnType("date");

                entity.Property(e => e.Discription).HasMaxLength(50);

                entity.Property(e => e.NameTask).HasMaxLength(50);

                entity.HasOne(d => d.IdUserCreationNavigation)
                    .WithMany(p => p.TaskIdUserCreationNavigations)
                    .HasForeignKey(d => d.IdUserCreation)
                    .HasConstraintName("UsersCreat");

                entity.HasOne(d => d.IdUserTakeNavigation)
                    .WithMany(p => p.TaskIdUserTakeNavigations)
                    .HasForeignKey(d => d.IdUserTake)
                    .HasConstraintName("UserTake");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("StatusTabl1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Sername).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
