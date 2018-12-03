using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecordStore.Data.Context;
using RecordStore.Data.Models;
using RecordStore.Data.Repositories.Interfaces;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Repositories.Implementations
{
    public class RecordRepository : GenericRepository<Record, RecordDo>, IRecordRepository
    {
        public RecordRepository(RecordStoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper){  }

        public async Task<RecordDo> GetWithArtist(int recordId)
        {
            var record = await _dbContext.Records.Include(r => r.Artist).SingleAsync(r => r.RecordId == recordId);
            return _mapper.Map<Record, RecordDo>(record);
        }
    }
}
