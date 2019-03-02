using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RecordStore.Data.Models;

namespace RecordStore.Data.Repositories.Interfaces
{
    public interface IGenericRepository<DB,DO> where DB : IShareableId where DO : class
    {
        Task<IEnumerable<DO>> GetAll();
        Task<DO> Get(int id);
        int Create(DO model);
        Task Update(DO model);
        Task<int> Count();
        void Delete(DO entity);
        IQueryable<DB> Where(Expression<Func<DB, bool>> predicate);
    }
}
