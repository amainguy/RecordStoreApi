using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecordStore.Data.Context
{
    class RecordStoreDbContextFactory : IDesignTimeDbContextFactory<RecordStoreDbContext>
    {
        public RecordStoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecordStoreDbContext>();
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\amain\\Projects\\RecordStore\\RecordStore.Api\\RecordStore.Data\\RecordStore.sqlite");
            return new RecordStoreDbContext(optionsBuilder.Options);
        }
    }
}
