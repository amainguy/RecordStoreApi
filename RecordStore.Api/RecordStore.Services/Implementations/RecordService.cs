using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Services.Implementations
{
    public class RecordService : IRecordService
    {
        public async Task<IEnumerable<Record>>  GetAll()
        {
            return new Record[0];
        }

        public async Task<Record> GetById(int id)
        {
            return new Record { Id = id };
        }
    }
}
