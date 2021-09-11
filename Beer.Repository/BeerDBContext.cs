using Beer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beer.Repository
{
    public sealed class BeerDBContext : DbContext
    {
        public BeerDBContext(DbContextOptions options) : base(options) { }

        public DbSet<BeerModel> Beers { get; set; }
        public DbSet<RatingsModel> Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerModel>()
          .HasKey(a => new { a.BeerId });

            modelBuilder.Entity<RatingsModel>()
         .HasKey(a => new { a.RatingId });

            modelBuilder.Entity<BeerModel>().HasData(
             new BeerModel { BeerId = 1, Name = "Three Floyds Zombie Dust", Type = "Pale Ale",AverageRatings=0 },
             new BeerModel { BeerId = 2, Name = "Sierra Nevada Pale Ale", Type = "Pale Ale", AverageRatings = 0 },
             new BeerModel { BeerId = 3, Name = "DRY IRISH STOUT ", Type = "Stout", AverageRatings = 0 },
             new BeerModel { BeerId = 4, Name = "MILK STOUT", Type = "Stout", AverageRatings = 0 }
             );

            modelBuilder.Entity<RatingsModel>().HasData(
           new RatingsModel { RatingId = 1, BeerId = 1, Ratings = 5  },
           new RatingsModel { RatingId = 2, BeerId = 1, Ratings = 5 },
           new RatingsModel { RatingId = 3, BeerId = 1, Ratings = 5 },
           new RatingsModel { RatingId = 4, BeerId = 1, Ratings = 5},
           new RatingsModel { RatingId = 5, BeerId = 1, Ratings = 3 },
           new RatingsModel { RatingId = 6, BeerId = 2, Ratings = 5},
           new RatingsModel { RatingId = 7, BeerId = 2, Ratings = 5},
           new RatingsModel { RatingId = 8, BeerId = 3, Ratings = 5},
           new RatingsModel { RatingId = 9, BeerId = 4, Ratings = 4},
           new RatingsModel { RatingId = 10, BeerId = 4, Ratings = 5 }
           );
        }
    }
}
