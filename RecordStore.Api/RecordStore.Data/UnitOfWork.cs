using RecordStore.Data.Context;
using RecordStore.Data.Repositories.Factories;
using RecordStore.Data.Repositories.Interfaces;

namespace RecordStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly RecordStoreDbContext _dbContext;  

        public UnitOfWork(IRepositoryFactory repositoryFactory, RecordStoreDbContext dbContext)
        {
            _repositoryFactory = repositoryFactory;
            _dbContext = dbContext;
        }

        public IRecordRepository Records => _repositoryFactory.GetRepository<IRecordRepository>();
        public IArtistRepository Artists => _repositoryFactory.GetRepository<IArtistRepository>();

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
