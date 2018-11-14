using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecordStore.Data.Context;
using RecordStore.Data.Models;
using RecordStore.Data.Repositories.Interfaces;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Repositories.Implementations
{
    public class ArtistRepository : BaseRepository, IArtistRepository
    {
        public ArtistRepository(RecordStoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<IEnumerable<ArtistDo>> GetAll()
        {
            return await _dbContext.Artists.Select(a => _mapper.Map<Artist, ArtistDo>(a) ).ToListAsync();
        }

        public async Task<ArtistDo> Get(int id)
        {
            var artist = await _dbContext.Artists.FindAsync(id);
            return _mapper.Map<Artist, ArtistDo>(artist);
        }
    }
}
