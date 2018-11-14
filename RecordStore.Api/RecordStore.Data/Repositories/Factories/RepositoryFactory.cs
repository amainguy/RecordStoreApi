using System;
using AutoMapper;
using RecordStore.Data.Context;
using RecordStore.Data.Repositories.Implementations;
using RecordStore.Data.Repositories.Interfaces;

namespace RecordStore.Data.Repositories.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly RecordStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public RepositoryFactory(RecordStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public T GetRepository<T>() where T : class
        {
            var repositoryType = typeof(T);
            if (repositoryType == typeof(IRecordRepository))
                return new RecordRepository(_dbContext, _mapper) as T;
            if (repositoryType == typeof(IArtistRepository))
                return new ArtistRepository(_dbContext, _mapper) as T;

            throw new ArgumentException("There's no repository for such a type", repositoryType.FullName);
        }
    }
}
