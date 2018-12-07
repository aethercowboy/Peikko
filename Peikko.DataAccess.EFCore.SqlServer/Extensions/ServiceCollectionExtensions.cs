using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Peikko.DataAccess.EFCore.Contexts;

namespace Peikko.DataAccess.EFCore.SqlServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSqlDAL<TContext>(this IServiceCollection services, string connectionString)
            where TContext : EFCoreDbContext
        {
            services.AddDbContext<EFCoreDbContext, TContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
