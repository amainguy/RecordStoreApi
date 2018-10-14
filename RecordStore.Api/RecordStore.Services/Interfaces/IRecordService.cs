using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.DomainObjects;

namespace RecordStore.Services.Interfaces
{
    public interface IRecordService
    {
        Task<IEnumerable<Record>> GetAll();
        Task<Record> GetById(int id);
    }
}
