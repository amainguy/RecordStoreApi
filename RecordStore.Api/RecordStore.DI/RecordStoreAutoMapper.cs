using AutoMapper;
using RecordStore.Data.Models;
using RecordStore.DomainObjects;

namespace RecordStore.DI
{
    public static class RecordStoreAutoMapper
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Record, RecordDo>().ReverseMap();
                config.CreateMap<Artist, ArtistDo>().ReverseMap();
            });
        }
    }
}
