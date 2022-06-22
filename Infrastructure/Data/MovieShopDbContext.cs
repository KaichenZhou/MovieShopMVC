using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDbContext:DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {
        }
        // multiple DbSets
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }



        //Only table genre, trailer and Purchase use the Data Annotations method
        //All others tables use the Fluent API method

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
            modelBuilder.Entity<Role>(ConfigureRole);

        }

        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).HasMaxLength(20);

        }
        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        }


        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.DateOfBirth).HasDefaultValueSql("getdate()");
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(256);          
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
            builder.Property(u => u.PhoneNumber).HasMaxLength(16);
            builder.Property(u => u.TwoFactorEnabled).HasDefaultValue(false);
            builder.Property(u => u.LockoutEndDate).HasDefaultValueSql("getdate()");
            builder.Property(u => u.LastLoginDateTime).HasDefaultValueSql("getdate()");
            builder.Property(u => u.IsLocked).HasDefaultValue(false);
            builder.HasIndex(u => new { u.AccessFailedCount }).IsUnique();
        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => new { p.UserId, p.MovieId }).IsUnique();
            builder.Property(p => p.PurchaseNumber).ValueGeneratedOnAdd();
            builder.Property(p => p.TotalPrice).HasColumnType("decimal(18, 2)").HasDefaultValue(9.9m);
            builder.Property(p => p.PurchaseDateTime).HasDefaultValueSql("getdate()");

            builder.Property(p => p.TotalPrice).HasColumnType("decimal(18, 2)").HasDefaultValue(9.9m);
            builder.Property(p => p.PurchaseDateTime).HasDefaultValueSql("getdate()");
        }


        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(f => f.Id);
            builder.HasIndex(f => new { f.UserId, f.MovieId }).IsUnique();

        }
        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(r => new { r.MovieId, r.UserId });
            builder.Property(r => r.Rating).HasColumnType("decimal(3, 2)");
            builder.Property(r => r.ReviewText).HasMaxLength(20000);

        }
        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.Gender).HasMaxLength(128);
            builder.Property(c => c.TmdbUrl).HasMaxLength(2084);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }



        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.CastId, mc.MovieId, mc.Character });

            builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Cast).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.CastId);
        }
        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(c => new { c.Id});
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.Gender).HasMaxLength(128);
            builder.Property(c => c.TmdbUrl).HasMaxLength(2084);
            builder.Property(c => c.ProfilePath).HasMaxLength(4096);

        }
        

        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mc => new { mc.MovieId, mc.CrewId, mc.Department, mc.Job });
        }


        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new { mg.MovieId,mg.GenreId });
        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // you can specify the Fluent API Rules
            // another way apart from data annoations for your schema

            builder.ToTable("Movie");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);

            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);

            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
