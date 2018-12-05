using Microsoft.EntityFrameworkCore;
using Peikko.Core.ResourceHolders;
using Peikko.DataAccess.EFCore.Contexts;
using Peikko.DataAccess.EFCore.EntityCollections;
using Peikko.DataAccess.Interfaces;
using Peikko.Domain.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Peikko.DataAccess.EFCore.Repositories
{
    internal class RepositoryAsync<TEntity, TKey> : DisposableResourceHolder, IRepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly EFCoreDbContext _dbContext;
        private DbSet<TEntity> _repository;

        public RepositoryAsync(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _repository = _dbContext.Set<TEntity>();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _repository.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> FindAsync(TKey id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var response = await _repository.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return response.Entity;
        }

        public async Task<IEntityCollection<TEntity>> ReadAsync()
        {
            var entities = _repository.AsQueryable();

            return await Task.FromResult(new EntityCollection<TEntity>(entities));
        }

        public async Task<IEntityCollection<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _repository.Where(predicate);

            return await Task.FromResult(new EntityCollection<TEntity>(entities));
        }

        public async Task<IEntityCollection<TEntity>> ReadAsync(ISpecification<TEntity> specification)
        {
            var queryableResultWithIncludes = specification.Includes
               .Aggregate(
                   _repository.AsQueryable(),
                   (current, include) => current.Include(include)
               );

            var secondaryResult = specification.IncludeStrings
                .Aggregate(
                    queryableResultWithIncludes,
                    (current, include) => current.Include(include)
                );

            var filteredResult = specification.Criteria != null
                ? secondaryResult.Where(specification.Criteria)
                : secondaryResult
                ;

            var orderedResult = filteredResult.OrderBy(x => 1);

            foreach (var sort in specification.Sorts)
            {
                orderedResult = sort.IsDescending
                    ? orderedResult.ThenByDescending(sort.Expression)
                    : orderedResult.ThenBy(sort.Expression)
                    ;
            }

            return await Task.FromResult(new EntityCollection<TEntity>(filteredResult));
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var response = _repository.Update(entity);
            await _dbContext.SaveChangesAsync();

            return response.Entity;
        }
    }
}
