using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecordStore.Data.Context
{
    class RecordStoreDbContextFactory : IDesignTimeDbContextFactory<RecordStoreDbContext>
    {
        public RecordStoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecordStoreDbContext>();
            optionsBuilder.UseSqlite("Data Source=RecordStore.sqlite");
            return new RecordStoreDbContext(optionsBuilder.Options);
        }
    }
}
