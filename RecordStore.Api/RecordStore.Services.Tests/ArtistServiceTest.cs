using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RecordStore.Data;
using RecordStore.Data.Repositories.Interfaces;
using RecordStore.DomainObjects;
using RecordStore.Services.Implementations;
using RecordStore.Services.Interfaces;

namespace RecordStore.Services.Tests
{
    [TestClass]
    public class ArtistServiceTest
    {
        private IUnitOfWork _unitOfWork;
        private IArtistService _subject;
        private int _artistId;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _artistId = 1;
        }

        [TestMethod]
        public async Task GetAll_ShouldCallUnitOfWorkGetAll()
        {
            CreateSubject();

            await _subject.GetAll();

            await _unitOfWork.Artists.Received().GetAll();
        }

        [TestMethod]
        public async Task GetById_WhenLoadRecordsIsFalse_ShouldCallGet()
        {
            CreateSubject();

            await _subject.GetById(_artistId, loadRecords: false);

            await _unitOfWork.Artists.Received().Get(_artistId);
        }

        [TestMethod]
        public async Task GetById_WhenLoadRecordsIsTrue_ShouldCallUnitOfWorkGetWithRecords()
        {
            CreateSubject();

            await _subject.GetById(_artistId, loadRecords: true);

            await _unitOfWork.Artists.Received().GetWithRecords(_artistId);
        }

        [TestMethod]
        public async Task Create_ShouldCallUnitOfWorkCreateAndSaveChanges()
        {
            CreateSubject();
            var artist = new ArtistDo();

            await _subject.Create(artist);

            _unitOfWork.Artists.Received().Create(artist);
            await _unitOfWork.Received().SaveChangesAsync();
        }

        [TestMethod]
        public async Task Update_ShouldCallUnitOfWorkUpdateAndSaveChanges()
        {
            CreateSubject();
            var artist = new ArtistDo { ArtistId = _artistId };

            await _subject.Update(_artistId, artist);

            await _unitOfWork.Artists.Received().Update(artist);
            await _unitOfWork.Received().SaveChangesAsync();
        }

        [TestMethod]
        public async Task Delete_ShouldCallUnitOfWorkDeleteAndSaveChanges()
        {
            CreateSubject();
            var artist = new ArtistDo { ArtistId = _artistId };

            await _subject.Delete(artist);

            _unitOfWork.Artists.Received().Delete(artist);
            await _unitOfWork.Received().SaveChangesAsync();
        }


        private void CreateSubject()
        {
            _unitOfWork.Artists.Returns(Substitute.For<IArtistRepository>());
            _unitOfWork.Artists.Get(_artistId).Returns(new ArtistDo {ArtistId = _artistId});
            _subject = new ArtistService(_unitOfWork);
        }
    }
}
