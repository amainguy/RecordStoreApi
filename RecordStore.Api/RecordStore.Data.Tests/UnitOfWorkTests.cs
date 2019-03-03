using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        private RecordStoreDbContext  _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<RecordStoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _dbContext = new RecordStoreDbContext(options);
            _repositoryFactory = Substitute.For<IRepositoryFactory>();
            _subject = new UnitOfWork(_repositoryFactory, _dbContext);
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
