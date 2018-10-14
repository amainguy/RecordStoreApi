using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.DomainObjects;

namespace RecordStore.Services.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAll();
        Task<Artist> GetById(int id);
    }
}
