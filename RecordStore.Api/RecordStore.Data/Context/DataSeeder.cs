using Microsoft.EntityFrameworkCore;
using RecordStore.Data.Models;

namespace RecordStore.Data
{
    public static class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(new Artist
            {
                ArtistId = 1,
                FirstName = "David",
                LastName = "Bowie",
            });

            modelBuilder.Entity<Record>().HasData(
                new Record { RecordId = 1, ArtistId = 1, ReleaseYear =  1973, Title = "Aladdin Sane"}
            );
        }
    }
}
