using System.Threading;
using System.Threading.Tasks;

namespace RecordStore.Data.Context
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
