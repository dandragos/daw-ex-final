using System;
using CarReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarReviewApp.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<Country> Countries { get; set; }

		public DbSet<Owner> Owners { get; set; }

		public DbSet<Car> Car { get; set; }

		public DbSet<CarOwner> CarOwners { get; set; }

		public DbSet<CarCategory> CarCategories { get; set; }

		public DbSet<Review> Reviews { get; set;  }

		public DbSet<Reviewer> Reviewers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<CarCategory>()
				.HasKey(kc => new { kc.CarId, kc.CategoryId });

			modelBuilder.Entity<CarCategory>()
				.HasOne(k => k.Car)
				.WithMany(kc => kc.CarCategories)
				.HasForeignKey(k => k.CarId);

            modelBuilder.Entity<CarCategory>()
                .HasOne(k => k.Category)
                .WithMany(kc => kc.CarCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<CarOwner>()
                .HasKey(ko => new { ko.CarId, ko.OwnerId });

            modelBuilder.Entity<CarOwner>()
                .HasOne(k => k.Car)
                .WithMany(ko => ko.CarOwners)
                .HasForeignKey(k => k.CarId);

            modelBuilder.Entity<CarOwner>()
                .HasOne(k => k.Owner)
                .WithMany(kc => kc.CarOwners)
                .HasForeignKey(o => o.OwnerId);
        }



    }
}

