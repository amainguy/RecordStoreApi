using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.DomainObjects;

namespace RecordStore.Services.Interfaces
{
    public interface IRecordService
    {
        Task<IEnumerable<RecordDo>> GetAll();
        Task<RecordDo> GetById(int id);
        Task Create(RecordDo record);
        Task Update(int id, RecordDo record);
        Task Delete(RecordDo record);
    }
}
