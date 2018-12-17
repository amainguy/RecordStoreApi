using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RecordStore.Data.Context;
using RecordStore.Data.Models;
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
            _dbContext.Artists.Add(new Artist());

            //await _subject.SaveChangesAsync();

            //_dbContext.ChangeTracker.HasChanges().Should();
        }

        public void CreateSubject()
        {
            _subject = new UnitOfWork(_repositoryFactory, _dbContext);
            
        }
    }
}
