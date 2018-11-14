using Microsoft.Extensions.DependencyInjection;

namespace RecordStore.DI
{
    public static class CompositionRoot
    {
        public static void AddRecordStoreDependencies(this IServiceCollection services)
        {
            services.AddRecordStoreServices();
            services.AddRecordStoreDataServices();
        }
    }
}
