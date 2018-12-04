using Peikko.Domain.Interfaces;
using System;
using System.Linq.Expressions;

namespace Peikko.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        TEntity Find(TKey id);
        IEntityCollection<TEntity> Read();
        IEntityCollection<TEntity> Read(Expression<Func<TEntity, bool>> predicate);
        IEntityCollection<TEntity> Read(ISpecification<TEntity> specification);

        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
