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

        public async Task Create(ArtistDo artist)
        {
            _unitOfWork.Artists.Create(artist);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(int id, ArtistDo artist)
        {
            await _unitOfWork.Artists.Update(id, artist);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(ArtistDo artist)
        {
            _unitOfWork.Artists.Delete(artist);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
