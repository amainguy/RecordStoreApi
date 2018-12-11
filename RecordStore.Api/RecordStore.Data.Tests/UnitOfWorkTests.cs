using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RecordStore.Data.Context;
using RecordStore.Data.Repositories.Factories;

namespace RecordStore.Data.Tests
{
    [TestClass]
    public class UnitOfWorkTests
    {
        private IUnitOfWork _subject;
        private IRepositoryFactory _repositoryFactory;
        private RecordStoreDbContext _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            _repositoryFactory = Substitute.For<IRepositoryFactory>();
            _dbContext = new RecordStoreDbContext();
        }


        [TestMethod]
        public async Task SaveChangesAsync_ShouldCallDbContextSaveChangesAsync()
        {
            CreateSubject();

            //await _subject.SaveChangesAsync();

            //await _dbContext.Received().SaveChangesAsync();
        }

        public void CreateSubject()
        {
            _subject = new UnitOfWork(_repositoryFactory, _dbContext);
            
        }
    }
}
