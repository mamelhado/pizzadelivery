using Delivery.Domain.Interfaces.Repositories;
using Delivery.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Delivery.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        public BaseService(IBaseRepository<TEntity> baseRepository) 
        {
            _baseRepository = baseRepository;
        }

        public async virtual Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default) 
        {
            return await _baseRepository.AddOrUpdateAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellation = default)
        {
            await _baseRepository.DeleteAsync(id, cancellation);
        }

        public IAsyncEnumerable<TEntity> GetAsync(CancellationToken cancellation = default)
        {
            return _baseRepository.GetAsync(cancellation);
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellation = default)
        {
            return await _baseRepository.GetByIdAsync(id, cancellation);
        }

        public IAsyncEnumerable<TEntity> GetWhereAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellation = default)
        {
            return _baseRepository.GetWhereAsync(expression, cancellation);
        }

        public async Task<TEntity> SelectWhereAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellation = default)
        {
            return await _baseRepository.SelectWhereAsync(expression, cancellation);
        }
    }
}