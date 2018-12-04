using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Peikko.DataAccess.Interfaces
{
    public interface IEntityCollection<TEntity>
    {
        IEntityCollection<TEntity> Filter(Expression<Func<TEntity, bool>> filter);
        IEntityCollection<TViewModel> Map<TViewModel>(IMapper mapper);
        IEntityCollection<TViewModel> Map<TViewModel>(Expression<Func<TEntity, TViewModel>> map);
        IEntityCollection<TEntity> Sort(params ISort<TEntity>[] sorts);
        IEnumerable<TEntity> AsEnumerable();
    }
}
