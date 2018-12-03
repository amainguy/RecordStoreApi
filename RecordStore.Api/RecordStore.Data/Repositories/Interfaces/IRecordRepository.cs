using System.Threading.Tasks;
using RecordStore.Data.Models;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Repositories.Interfaces
{
    public interface IRecordRepository : IGenericRepository<Record, RecordDo>
    {
        Task<RecordDo> GetWithArtist(int artistId);
    }
}
