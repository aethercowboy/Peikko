using Microsoft.EntityFrameworkCore;
using Peikko.DataAccess.EFCore.Contexts;
using Sample.Domain.Models;

namespace Sample.DataAccess.Contexts
{
    public class PeikkoDbContext : EFCoreDbContext
    {
        public PeikkoDbContext(DbContextOptions<PeikkoDbContext> options) : base(options)
        {
        }

        public DbSet<Publisher> Publishers { get; set; }
    }
}
