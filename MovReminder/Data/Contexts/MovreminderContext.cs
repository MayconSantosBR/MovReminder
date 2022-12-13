using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovReminder.Data.Entities;

namespace MovReminder.Data.Contexts;

public partial class MovreminderContext : DbContext
{
    public MovreminderContext()
    {
    }

    public MovreminderContext(DbContextOptions<MovreminderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WatchedMovie> WatchedMovies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=movreminder2;User Id=postgres;Password=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.IdDirector).HasName("directors_pkey");

            entity.ToTable("directors");

            entity.Property(e => e.IdDirector).HasColumnName("idDirector");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.Property(e => e.IdGender).HasColumnName("idGender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.IdMovie).HasName("movies_pkey");

            entity.ToTable("movies");

            entity.Property(e => e.IdMovie).HasColumnName("idMovie");
            entity.Property(e => e.DateOfShow).HasColumnName("dateOfShow");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.IdDirector).HasColumnName("idDirector");
            entity.Property(e => e.IdGender).HasColumnName("idGender");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.IdDirectorNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.IdDirector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idDirector");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idGender");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<WatchedMovie>(entity =>
        {
            entity.HasKey(e => new { e.IdMovie, e.IdUser }).HasName("watchedMovies_pkey");

            entity.ToTable("watchedMovies");

            entity.Property(e => e.IdMovie).HasColumnName("idMovie");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Liked).HasColumnName("liked");

            entity.HasOne(d => d.IdMovieNavigation).WithMany(p => p.WatchedMovies)
                .HasForeignKey(d => d.IdMovie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idMovie");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.WatchedMovies)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
