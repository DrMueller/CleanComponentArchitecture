using Mmu.Cca.DataAccess.Areas.DbContexts.Contexts;

namespace Mmu.Cca.DataAccess.Areas.Repositories.Base
{
    internal interface IRepositoryBase
    {
        internal void Initialize(IAppDbContext dbContext);
    }
}