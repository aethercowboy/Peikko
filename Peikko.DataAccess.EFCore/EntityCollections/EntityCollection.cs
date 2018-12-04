using AutoMapper;
using AutoMapper.QueryableExtensions;
using Peikko.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Peikko.Repository.EFCore.EntityCollections
{
    internal class EntityCollection<TEntity> : IEntityCollection<TEntity>
    {
        private readonly IQueryable<TEntity> _queryable;

        public EntityCollection(IQueryable<TEntity> queryable)
        {
            _queryable = queryable;
        }

        public IEnumerable<TEntity> AsEnumerable() => _queryable;
        public IEntityCollection<TEntity> Filter(Expression<Func<TEntity, bool>> filter) => new EntityCollection<TEntity>(_queryable.Where(filter));
        public IEntityCollection<TViewModel> Map<TViewModel>(IMapper mapper) => new EntityCollection<TViewModel>(_queryable.ProjectTo<TViewModel>(mapper.ConfigurationProvider));
        public IEntityCollection<TViewModel> Map<TViewModel>(Expression<Func<TEntity, TViewModel>> map) => new EntityCollection<TViewModel>(_queryable.Select(map));
        public IEntityCollection<TEntity> Sort(params ISort<TEntity>[] sorts)
        {
            if (sorts.Any())
            {
                var firstSort = sorts.First();

                var q = firstSort.IsDescending
                    ? _queryable.OrderByDescending(firstSort.Expression)
                    : _queryable.OrderBy(firstSort.Expression)
                    ;

                for (var i = 1; i < sorts.Length; ++i)
                {
                    var sort = sorts[i];

                    q = sort.IsDescending
                        ? q.ThenByDescending(sort.Expression)
                        : q.ThenBy(sort.Expression)
                        ;
                }

                return new EntityCollection<TEntity>(q);
            }

            return this;
        }
    }
}
