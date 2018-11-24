using AutoMapper;
using RecordStore.Data.Context;
using RecordStore.Data.Models;
using RecordStore.Data.Repositories.Interfaces;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Repositories.Implementations
{
    public class ArtistRepository : GenericRepository<Artist, ArtistDo>, IArtistRepository
    {
        public ArtistRepository(RecordStoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
