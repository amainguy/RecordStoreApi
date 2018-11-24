using RecordStore.Data.Models;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Repositories.Interfaces
{
    public interface IArtistRepository : IGenericRepository<Artist, ArtistDo>
    {
    }
}
