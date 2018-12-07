using Peikko.Domain.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Peikko.DataAccess.Interfaces
{
    public interface IRepositoryAsync<TEntity, TKey> : IRepository<TEntity, TKey>, IDisposable
        where TEntity : class, IEntity<TKey>

    {
        Task<TEntity> FindAsync(TKey id);
        Task<IEntityCollection<TEntity>> ReadAsync();
        Task<IEntityCollection<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEntityCollection<TEntity>> ReadAsync(ISpecification<TEntity> specification);

        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
