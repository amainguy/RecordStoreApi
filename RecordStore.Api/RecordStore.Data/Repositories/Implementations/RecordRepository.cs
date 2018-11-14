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
    public class RecordRepository : BaseRepository, IRecordRepository
    {
        public RecordRepository(RecordStoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper){  }

        public async Task<IEnumerable<RecordDo>> GetAll()
        {
            return await _dbContext.Records.Select(r => _mapper.Map<Record, RecordDo>(r)).ToListAsync();
        }

        public async Task<RecordDo> Get(int id)
        {
            var record = await _dbContext.Records.FindAsync(id);
            return _mapper.Map<Record, RecordDo>(record);
        }
    }
}
