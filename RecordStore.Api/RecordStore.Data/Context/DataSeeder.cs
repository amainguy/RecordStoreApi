using System;
using Microsoft.EntityFrameworkCore;
using RecordStore.Data.Models;

namespace RecordStore.Data.Context
{
    public static class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData( new Artist()
            {
                ArtistId = 1,
                FirstName = "David",
                LastName = "Bowie",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Artist>().HasData(new Artist()
            {
                ArtistId = 2,
                FirstName = "Chet",
                LastName = "Atkins",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Record>().HasData(new Record()
            {
                RecordId = 1,
                ArtistId = 1,
                ReleaseYear = 1969,
                Title = "Space Oddity",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Record>().HasData(new Record()
            {
                RecordId = 2,
                ArtistId = 1,
                ReleaseYear = 1970,
                Title = "The Man Who Sold The World",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Record>().HasData(new Record()
            {
                RecordId = 3,
                ArtistId = 1,
                ReleaseYear = 1971,
                Title = "Hunky Dory",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Record>().HasData(new Record()
            {
                RecordId = 4,
                ArtistId = 1,
                ReleaseYear = 1972,
                Title = "The Rise and Fall of Ziggy Stardust and the Spiders from Mars",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Record>().HasData( new Record()
            {
                RecordId = 5,
                ArtistId = 1,
                ReleaseYear =  1973,
                Title = "Aladdin Sane",
                Created = DateTime.UtcNow
            });

            modelBuilder.Entity<Record>().HasData( new Record()
            {
                RecordId = 6,
                ArtistId = 2,
                ReleaseYear = 1964,
                Title = "My Favorite Guitars",
                Created = DateTime.UtcNow
            });
        }
    }
}
