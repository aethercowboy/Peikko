using Peikko.DataAccess.Interfaces;

namespace Peikko.BusinessLogic.Interfaces
{
    public interface IService<TEntity, TKey>
    {
        IEntityCollection<TEntity> Read();
        TEntity Find(TKey id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TKey id);
    }
}
