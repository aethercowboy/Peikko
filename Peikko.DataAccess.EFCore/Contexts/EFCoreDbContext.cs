using Microsoft.EntityFrameworkCore;

namespace Peikko.Repository.EFCore.Contexts
{
    //public interface IEFCoreDbContext
    //{
    //    DbSet<TEntity> Set<TEntity>()
    //        where TEntity : class;

    //    int SaveChanges();
    //}

    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
