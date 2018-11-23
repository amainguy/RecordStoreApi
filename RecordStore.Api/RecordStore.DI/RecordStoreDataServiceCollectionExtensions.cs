using Microsoft.Extensions.DependencyInjection;
using RecordStore.Data;
using RecordStore.Data.Context;
using RecordStore.Data.Repositories.Factories;

namespace RecordStore.DI
{
    internal static class RecordStoreDataServiceCollectionExtensions
    {
        public static void AddRecordStoreDataServices (this IServiceCollection services)
        {
            services.AddDbContext<RecordStoreDbContext>();
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
