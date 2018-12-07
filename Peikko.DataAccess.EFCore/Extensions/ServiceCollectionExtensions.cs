using Microsoft.Extensions.DependencyInjection;
using Peikko.Core.Extensions;
using Peikko.DataAccess.Interfaces;
using Peikko.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Peikko.DataAccess.EFCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories<TEntity, TKey>(this IServiceCollection services, Type repositoryType, IList<Type> includes = null, IList<Type> excludes = null)
            where TEntity : class, IEntity<TKey>
        {
            var baseRepository = typeof(IRepositoryAsync<,>);
            

            if (!baseRepository.IsAssignableFromGenericType(repositoryType))
                throw new ArgumentException($"Type must be assignable to type {baseRepository.Name}", nameof(repositoryType));

            var t = typeof(TEntity);

            var assignableTypes = t.GetAssignableTypes();

            if (includes != null)
            {
                assignableTypes = assignableTypes.Where(x => includes.Contains(x));
            }

            if (excludes != null)
            {
                assignableTypes = assignableTypes.Where(x => !excludes.Contains(x));
            }

            foreach (var type in assignableTypes)
            {
                var keyType = type.GetProperty("Id").PropertyType;

                var interfaceType = baseRepository.MakeGenericType(new Type[] { type, keyType });

                Type repoType;

                if (repositoryType.IsGenericType)
                {
                    var args = repositoryType.GetGenericArguments();

                    var entity = args.FirstOrDefault(x => x.Name == "TEntity");
                    var key = args.FirstOrDefault(x => x.Name == "TKey");

                    var types = new List<Type>();

                    if (entity != null)
                    {
                        types.Add(type);
                    }

                    if (key != null)
                    {
                        types.Add(typeof(TKey));
                    }

                    repoType = repositoryType.MakeGenericType(types.ToArray());
                    
                } else
                {
                    repoType = repositoryType;
                }

                services.AddScoped(interfaceType, repoType);
            }
        }
    }
}
