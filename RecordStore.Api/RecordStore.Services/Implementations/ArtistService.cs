using System.Collections.Generic;
using System.Threading.Tasks;
using RecordStore.Data;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Services.Implementations
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ArtistDo>> GetAll()
        {
            return await _unitOfWork.Artists.GetAll();
        }

        public async Task<ArtistDo> GetById(int id)
        {
            return await _unitOfWork.Artists.Get(id);
        }

        public async Task<ArtistDo> Create(ArtistDo artist)
        {
            _unitOfWork.Artists.Create(artist);
            await _unitOfWork.SaveChangesAsync();
            return artist;
        }
    }
}
