using Peikko.DataAccess.Interfaces;
using System;
using System.Linq.Expressions;

namespace Peikko.DataAccess.Specifications.Sorts
{
    public class Sort<TEntity> : ISort<TEntity>
    {
        public Expression<Func<TEntity, object>> Expression { get; }

        public bool IsDescending { get; }

        public Sort(Expression<Func<TEntity,object>> expression, bool isDescending = false)
        {
            Expression = expression;
            IsDescending = isDescending;
        }
    }
}
