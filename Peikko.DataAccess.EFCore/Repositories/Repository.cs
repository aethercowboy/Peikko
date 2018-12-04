using Microsoft.EntityFrameworkCore;
using Peikko.Domain.Interfaces;
using Peikko.Repository.EFCore.Contexts;
using Peikko.Repository.EFCore.EntityCollections;
using Peikko.Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Peikko.Repository.EFCore.Repositories
{
    internal class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly EFCoreDbContext _dbContext;
        private DbSet<TEntity> _repository;

        public Repository(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _repository = _dbContext.Set<TEntity>();
        }


        public void Delete(TEntity entity)
        {
            _repository.Remove(entity);
            _dbContext.SaveChanges();
        }

        public TEntity Find(TKey id)
        {
            return _repository.Find(id);
        }

        public TEntity Insert(TEntity entity)
        {
            var response = _repository.Add(entity);
            _dbContext.SaveChanges();

            return response.Entity;
        }

        public IEntityCollection<TEntity> Read()
        {
            var entities = _repository.AsQueryable();

            return new EntityCollection<TEntity>(entities);
        }

        public IEntityCollection<TEntity> Read(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _repository.Where(predicate);

            return new EntityCollection<TEntity>(entities);
        }

        public IEntityCollection<TEntity> Read(ISpecification<TEntity> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(
                    _repository.AsQueryable(),
                    (current, include) => current.Include(include)
                );

            var secondaryResult = spec.IncludeStrings
                .Aggregate(
                    queryableResultWithIncludes,
                    (current, include) => current.Include(include)
                );

            var filteredResult = spec.Criteria != null
                ? secondaryResult.Where(spec.Criteria)
                : secondaryResult
                ;

            var orderedResult = filteredResult.OrderBy(x => 1);

            foreach (var sort in spec.Sorts)
            {
                orderedResult = sort.IsDescending
                    ? orderedResult.ThenByDescending(sort.Expression)
                    : orderedResult.ThenBy(sort.Expression)
                    ;
            }

            return new EntityCollection<TEntity>(filteredResult);
        }

        public TEntity Update(TEntity entity)
        {
            var response = _repository.Update(entity);
            _dbContext.SaveChanges();

            return response.Entity;
        }
    }
}
