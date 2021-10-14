using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mmu.Cca.DataAccess.Areas.DbContexts.Contexts.Implementation
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public ChangeTracker ChangeTrackerr => base.ChangeTracker;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw());
        }

        ////protected override void OnModelCreating(ModelBuilder modelBuilder)
        ////{
        ////    base.OnModelCreating(modelBuilder);
        ////    modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfigBase<>).Assembly);
        ////}
    }
}