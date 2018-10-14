using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Services.Implementations
{
    public class ArtistService : IArtistService
    {
        public async Task<IEnumerable<Artist>> GetAll()
        {
            return new Artist[0];
        }

        public async Task<Artist> GetById(int id)
        {
            return new Artist { Id = id };
        }
    }
}
