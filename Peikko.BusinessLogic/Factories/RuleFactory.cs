using Peikko.Domain.Interfaces;
using Peikko.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Peikko.Service.Factories
{
    public class RuleFactory<TEntity, TKey> : IRuleCollection<TEntity, TKey>
        where TEntity : IEntity<TKey>
    {
        private readonly IList<IRule<IEntity<TKey>>> _businessLogics;

        public RuleFactory(IServiceProvider provider)
        {
            var type = typeof(IRule<>);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p =>
                    type.IsAssignableFrom(p)
                    && p.IsGenericType
                    && p.GetGenericTypeDefinition().IsAssignableFrom(typeof(TEntity))
                )
                ;

            _businessLogics = types.Select(x => provider.GetService(x))
                .Cast<IRule<IEntity<TKey>>>()
                .ToList()
                ;
        }

        public void PostActions(TEntity entity)
        {
            foreach (var b in _businessLogics)
            {
                b.PostActions(entity);
            }
        }

        public void PreActions(TEntity entity)
        {
            foreach (var b in _businessLogics)
            {
                b.PreActions(entity);
            }
        }

        public bool Validate(TEntity entity)
        {
            var result = true;

            foreach (var b in _businessLogics)
            {
                result = b.Validate(entity);

                if (!result) break;
            }

            return result;
        }
    }
}
