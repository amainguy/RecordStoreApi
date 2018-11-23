using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RecordStore.Data.Models;
using RecordStore.DomainObjects;

namespace RecordStore.DI
{
    public static class CompositionRoot
    {
        public static void AddRecordStore(this IServiceCollection services)
        {
            services.AddRecordStoreServices();
            services.AddRecordStoreDataServices();

            services.AddAutoMapper(c =>
            {
                c.CreateMap<Record, RecordDo>();
                c.CreateMap<Artist, ArtistDo>();
            });
        }
    }
}
