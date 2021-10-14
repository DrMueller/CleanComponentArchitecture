using System;
using Mmu.Cca.Bc.Base.DomainServices.Repositories;
using Mmu.Cca.DataAccess.Areas.DbContexts.Contexts;

namespace Mmu.Cca.DataAccess.Areas.UnitOfWorks.Servants
{
    public interface IRepositoryCache
    {
        TRepo GetRepository<TRepo>(Type repositoryType, IAppDbContext dbContext)
            where TRepo : IRepository;
    }
}