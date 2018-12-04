using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Peikko.Repository.EFCore.Contexts;
using Peikko.Repository.EFCore.Repositories;
using Peikko.Repository.Interfaces;

namespace Peikko.Repository.EFCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEFCoreDbContext<TContext>(this IServiceCollection services, string connectionString)
            where TContext : EFCoreDbContext
            =>
            services.AddDbContext<EFCoreDbContext, TContext>(options => { options.UseSqlServer(connectionString); });

        public static void AddEFCoreRepositoryInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}
