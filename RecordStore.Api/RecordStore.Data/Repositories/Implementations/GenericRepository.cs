using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecordStore.Data.Context;
using RecordStore.Data.Models;
using RecordStore.Data.Repositories.Interfaces;

namespace RecordStore.Data.Repositories.Implementations
{
    public abstract class GenericRepository<TEntity, TDomainObject> : IGenericRepository<TEntity, TDomainObject> where TEntity : class, IShareableId where TDomainObject : class
    {
        protected RecordStoreDbContext _dbContext;
        protected IMapper _mapper;

        protected GenericRepository(RecordStoreDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TDomainObject>> GetAll()
        {
            return await _dbContext.Set<TEntity>().Select(entity => _mapper.Map<TEntity, TDomainObject>(entity)).ToListAsync();
        }

        public async Task<TDomainObject> Get(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            return _mapper.Map<TEntity, TDomainObject>(entity);
        }

        public int Create(TDomainObject model)
        {
            var entity = _mapper.Map<TDomainObject, TEntity>(model);
            _dbContext.Set<TEntity>().Add(entity);
            return entity.GetId();
        }

        public async Task Update(int id, TDomainObject model)
        {
            var mappedEntity = _mapper.Map<TDomainObject, TEntity>(model);
            var foundEntity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Entry(foundEntity).CurrentValues.SetValues(mappedEntity);
        }

        public async Task<int> Count()
        {
            return await _dbContext.Set<TEntity>().CountAsync();
        }

        public void Delete(TDomainObject model)
        {
            var entity = _mapper.Map<TDomainObject, TEntity>(model);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }
    }
}
