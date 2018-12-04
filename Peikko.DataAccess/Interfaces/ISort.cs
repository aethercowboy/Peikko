using System;
using System.Linq.Expressions;

namespace Peikko.DataAccess.Interfaces
{
    public interface ISort<TEntity>
    {
        Expression<Func<TEntity, object>> Expression { get; }
        bool IsDescending { get; }
    }
}
