using Peikko.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Peikko.DataAccess.Specifications
{
    public class Specification<TEntity> : ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; }

        public IList<Expression<Func<TEntity, object>>> Includes => new List<Expression<Func<TEntity,object>>>();

        public IList<string> IncludeStrings => new List<string>();

        public IList<ISort<TEntity>> Sorts => new List<ISort<TEntity>>();

        public Specification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected virtual void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string include)
        {
            IncludeStrings.Add(include);
        }

        protected virtual void AddSort(ISort<TEntity> sort)
        {
            Sorts.Add(sort);
        }
    }
}
