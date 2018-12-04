using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Peikko.DataAccess.Interfaces
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
        IList<Expression<Func<TEntity, object>>> Includes { get; }
        IList<string> IncludeStrings { get; }
        IList<ISort<TEntity>> Sorts { get; }
    }
}
