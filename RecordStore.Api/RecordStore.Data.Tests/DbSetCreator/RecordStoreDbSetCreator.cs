using System;
using System.Collections.Generic;
using RecordStore.Data.Context;
using RecordStore.Data.Models;

namespace RecordStore.Data.Tests.DbSetCreator
{
    public static class RecordStoreDbSetCreator
    {
        public static void CreateDbSet(RecordStoreDbContext dbContext)
        {
            dbContext.Artists.Add(new Artist {ArtistId = 1, FirstName = "David", LastName = "Bowie", Created = DateTime.UtcNow });
            dbContext.Artists.Add(new Artist {ArtistId = 2, FirstName = "Bob", LastName = "Dylan", Created = DateTime.UtcNow});
            dbContext.Records.Add(new Record { Title = "Space Oddity", ArtistId = 1, ReleaseYear = 1969 });
            dbContext.SaveChanges();
        }
    }
}
