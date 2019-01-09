using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RecordStore.Data.Context;
using RecordStore.Data.Repositories.Factories;
using RecordStore.Data.Repositories.Interfaces;

namespace RecordStore.Data.Tests
{
    [TestClass]
    public class UnitOfWorkTests
    {
        private IUnitOfWork _subject;
        private IRepositoryFactory _repositoryFactory;
        private IDbContext  _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            _dbContext = Substitute.For<IDbContext>();
            _repositoryFactory = Substitute.For<IRepositoryFactory>();
            _subject = new UnitOfWork(_repositoryFactory, _dbContext);
        }


        [TestMethod]
        public async Task SaveChangesAsync_ShouldCallDbContextSaveChangesAsync()
        {
            await _subject.SaveChangesAsync();
   
            await _dbContext.Received().SaveChangesAsync();
        }

        [TestMethod]
        public void Records_ShouldCallRecordRepository()
        { 
            var recordsRepository = _subject.Records;

            _repositoryFactory.Received().GetRepository<IRecordRepository>();
        }

        [TestMethod]
        public void Artists_ShouldCallArtistRepository()
        {
            var artistsRepository = _subject.Artists;

            _repositoryFactory.Received().GetRepository<IArtistRepository>();
        }
    }
}
