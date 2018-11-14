using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.DomainObjects;

namespace RecordStore.Services.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDo>> GetAll();
        Task<ArtistDo> GetById(int id);
    }
}
