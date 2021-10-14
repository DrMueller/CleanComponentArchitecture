using Mmu.Cca.DataAccess.Areas.DbContexts.Contexts;

namespace Mmu.Cca.DataAccess.Areas.DbContexts.Factories
{
    public interface IAppDbContextFactory
    {
        IAppDbContext Create();
    }
}