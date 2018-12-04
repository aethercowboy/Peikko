using Microsoft.EntityFrameworkCore;
using Peikko.Domain.PeikkoDomain.Models;
using Peikko.Repository.EFCore.Contexts;

namespace Peikko.Contexts
{
    public class PeikkoDbContext : EFCoreDbContext
    {
        public PeikkoDbContext(DbContextOptions<PeikkoDbContext> options) : base(options)
        {
        }

        public DbSet<Publisher> Publishers { get; set; }
    }
}
