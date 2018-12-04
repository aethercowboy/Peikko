using Peikko.Domain.Interfaces;
using Peikko.DataAccess.Interfaces;
using Peikko.BusinessLogic.Interfaces;
using System.ComponentModel;

namespace Peikko.BusinessLogic.Services
{
    [DataObject]
    public abstract class Service<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly IRepository<TEntity, TKey> _repository;
        protected readonly IRuleCollection<TEntity, TKey> _rules;

        protected Service(IRepository<TEntity, TKey> repository, IRuleCollection<TEntity, TKey> rules)
        {
            _repository = repository;
            _rules = rules;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public TEntity Add(TEntity entity)
        {
            var isValid = _rules.Validate(entity);

            if (!isValid) return entity;

            _rules.PreActions(entity);

            _repository.Insert(entity);

            _rules.PostActions(entity);

            return entity;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Delete(TKey id)
        {
            var entity = Find(id);
            _repository.Delete(entity);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TEntity Find(TKey id) => _repository.Find(id);

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IEntityCollection<TEntity> Read() => _repository.Read();

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public TEntity Update(TEntity entity)
        {
            var isValid = _rules.Validate(entity);

            if (!isValid) return entity;

            _rules.PreActions(entity);

            _repository.Update(entity);

            _rules.PostActions(entity);

            return entity;
        }
    }
}
