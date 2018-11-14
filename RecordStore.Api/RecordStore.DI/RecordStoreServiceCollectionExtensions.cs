using Microsoft.Extensions.DependencyInjection;
using RecordStore.Services.Implementations;
using RecordStore.Services.Interfaces;

namespace RecordStore.DI
{
    internal static class RecordStoreServiceCollectionExtensions
    {
        public static void AddRecordStoreServices(this IServiceCollection services)
        {
            services.AddTransient<IArtistService, ArtistService>();
            services.AddTransient<IRecordService, RecordService>();
        }
    }
}
