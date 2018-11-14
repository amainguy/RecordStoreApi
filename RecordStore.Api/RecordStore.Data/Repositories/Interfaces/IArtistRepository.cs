using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.Data.Models;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Repositories.Interfaces
{
    public interface IArtistRepository
    {
        Task<IEnumerable<ArtistDo>> GetAll();
        Task<ArtistDo> Get(int id);
    }
}
