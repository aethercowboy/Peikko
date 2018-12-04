using Peikko.Repository.Interfaces;

namespace Peikko.Service.Interfaces
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
