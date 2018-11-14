using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Repositories.Interfaces
{
    public interface IRecordRepository
    {
        Task<IEnumerable<RecordDo>> GetAll();
        Task<RecordDo> Get(int id);
    }
}
