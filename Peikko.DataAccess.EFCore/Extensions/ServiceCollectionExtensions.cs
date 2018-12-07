using Microsoft.Extensions.DependencyInjection;
using Peikko.Core.Extensions;
using Peikko.DataAccess.EFCore.Repositories;
using Peikko.DataAccess.Interfaces;
using Peikko.Domain.Interfaces;
using System;

namespace Peikko.DataAccess.EFCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories<TEntity, TKey, TRepository>(this IServiceCollection services)
            where TEntity : class, IEntity<TKey>
            where TRepository : IRepository<TEntity, TKey>
        {
            var t = typeof(TEntity);

            foreach (var type in t.GetAssignableTypes())
            {
                var keyType = type.GetProperty("Id").PropertyType;

                var interfaceType = typeof(IRepository<,>).MakeGenericType(new Type[] { type, keyType});
                var repoType = typeof(TRepository); // todo - coerce into TEntity Repo.

                services.AddScoped(interfaceType, repoType);
            }

            //services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}
