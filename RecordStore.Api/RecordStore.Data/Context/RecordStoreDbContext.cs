using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecordStore.Data.Models;

namespace RecordStore.Data.Context
{
    public class RecordStoreDbContext : DbContext, IDbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public RecordStoreDbContext() { }
        public RecordStoreDbContext(DbContextOptions options) : base(options) { }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuditInfo();
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\amain\\Projects\\RecordStore\\RecordStore.Api\\RecordStore.Data\\RecordStore.sqlite");
        }

        private void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State ==  EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().HasOne(r => r.Artist).WithMany(a => a.Records);
            DataSeeder.SeedData(modelBuilder);
        }
    }
}
