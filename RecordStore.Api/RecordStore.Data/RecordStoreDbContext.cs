using Microsoft.EntityFrameworkCore;
using RecordStore.Data.Models;

namespace RecordStore.Data
{
    class RecordStoreDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public RecordStoreDbContext(DbContextOptions<RecordStoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().HasOne(r => r.Artist).WithMany(a => a.Records);
        }

    }
}
