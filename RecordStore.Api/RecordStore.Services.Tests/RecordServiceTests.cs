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
    public class RecordServiceTests
    {
        private IRecordService _subject;
        private IUnitOfWork _unitOfWork;
        private int _recordId;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _recordId = 1;
        }

        [TestMethod]
        public async Task GetAll_ShouldCallUnitOfWorkGetAll()
        {
            CreateSubject();

            await _subject.GetAll();

            await _unitOfWork.Records.Received().GetAll();
        }

        [TestMethod]
        public async Task GetById_WhenLoadArtistIsFalse_ShouldCallGet()
        {
            CreateSubject();

            await _subject.GetById(_recordId, loadArtist: false);

            await _unitOfWork.Records.Received().Get(_recordId);
        }

        [TestMethod]
        public async Task GetById_WhenLoadArtistIsTrue_ShouldCallGetWithArtist()
        {
            CreateSubject();

            await _subject.GetById(_recordId, loadArtist: true);

            await _unitOfWork.Records.Received().GetWithArtist(_recordId);
        }

        [TestMethod]
        public async Task Create_ShouldCallUnitOfWorkCreateAndSaveChanges()
        {
            CreateSubject();
            var record = new RecordDo();

            await _subject.Create(record);

            _unitOfWork.Records.Received().Create(record);
            await _unitOfWork.Received().SaveChangesAsync();

        }

        [TestMethod]
        public async Task Update_ShouldCallUnitOfWorkUpdateAndSaveChanges()
        {
            CreateSubject();
            var record = new RecordDo();

            await _subject.Update(_recordId, record);

            await _unitOfWork.Records.Received().Update(_recordId, record);
            await _unitOfWork.Received().SaveChangesAsync();
        }

        [TestMethod]
        public async Task Delete_ShouldCallUnitOfWorkDeleteAndSaveChanges()
        {
            CreateSubject();
            var record = new RecordDo();

            await _subject.Delete(record);
            await _unitOfWork.Received().SaveChangesAsync();
        }

        private void CreateSubject()
        {
            _unitOfWork.Records.Returns(Substitute.For<IRecordRepository>());
            _unitOfWork.Records.Get(_recordId).Returns(new RecordDo { RecordId = _recordId });
            _subject = new RecordService(_unitOfWork);
        }
    }
}
