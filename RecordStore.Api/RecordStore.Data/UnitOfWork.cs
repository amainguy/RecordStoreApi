using System.Threading.Tasks;
using RecordStore.Data.Context;
using RecordStore.Data.Repositories.Factories;
using RecordStore.Data.Repositories.Interfaces;

namespace RecordStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IDbContext _dbContext;  

        public UnitOfWork(IRepositoryFactory repositoryFactory, IDbContext dbContext)
        {
            _repositoryFactory = repositoryFactory;
            _dbContext = dbContext;
        }

        public IRecordRepository Records => _repositoryFactory.GetRepository<IRecordRepository>();
        public IArtistRepository Artists => _repositoryFactory.GetRepository<IArtistRepository>();

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
