using Delivery.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DeliveryContext _context;
        public BaseRepository(DeliveryContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellation = default)
        {
            _context.Set<TEntity>().Remove(await GetByIdAsync(id));
            await SaveAsync(cancellation);
        }

        public async IAsyncEnumerable<TEntity> GetAsync(CancellationToken cancellation = default)
        {
            var entities = _context.Set<TEntity>().AsAsyncEnumerable();

            await foreach (var entity in entities)
            {
                yield return entity;
            }
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellation = default)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async IAsyncEnumerable<TEntity> GetWhereAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellation = default)
        {
            var entities = _context.Set<TEntity>().Where(expression).AsAsyncEnumerable();

            await foreach (var entity in entities)
            {
                yield return entity;
            }
        }

        public async Task<TEntity> SelectWhereAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellation = default)
        {
            return await _context.Set<TEntity>().Where(expression).FirstOrDefaultAsync(cancellation);
        }

        private async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellation = default)
        {
            _context.Update(entity);
            int lineAffeceted = await SaveAsync(cancellation);
            if (lineAffeceted == 0)
                throw new Exception($"Fail in update Trnasaction");

            return entity;

        }

        private async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellation = default)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellation);
            int lineAffeceted = await SaveAsync(cancellation);
            if (lineAffeceted == 0)
                throw new Exception($"Fail in insert Trnasaction");

            return entity;
        }

        public async Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellation = default)
        {
            dynamic obj = entity;
            
            if (obj.Id == 0)
                return await AddAsync(entity, cancellation);
            else
                return await UpdateAsync(entity, cancellation);
            
        }

        private async Task<int> SaveAsync(CancellationToken cancellation = default)
        {
            return await _context.SaveChangesAsync(cancellation);
        }
    }
}
