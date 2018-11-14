using AutoMapper;
using RecordStore.Data.Context;

namespace RecordStore.Data.Repositories.Implementations
{
    public abstract class BaseRepository
    {
        protected readonly RecordStoreDbContext _dbContext;
        protected readonly IMapper _mapper;

        protected BaseRepository(RecordStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
