using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellation = default);

        Task<TEntity> SelectWhereAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellation = default);

        Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellation = default);

        Task DeleteAsync(int id, CancellationToken cancellation = default);

        IAsyncEnumerable<TEntity> GetAsync(CancellationToken cancellation = default);

        IAsyncEnumerable<TEntity> GetWhereAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellation = default);
    }
}
