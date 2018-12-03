using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecordStore.Data.Context;
using RecordStore.Data.Models;
using RecordStore.Data.Repositories.Interfaces;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Repositories.Implementations
{
    public class ArtistRepository : GenericRepository<Artist, ArtistDo>, IArtistRepository
    {
        public ArtistRepository(RecordStoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<ArtistDo> GetWithRecords(int id)
        {
            var artist = await _dbContext.Artists.Include(a => a.Records).SingleAsync(a => a.ArtistId == id);
            return _mapper.Map<Artist, ArtistDo>(artist);
        }
    }
}
