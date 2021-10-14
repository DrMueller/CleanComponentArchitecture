using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.DataAccess.Areas.Repositories.Base.Implementation;

namespace Mmu.Cca.DataAccess.Areas.Repositories.Generic.Implementation
{
    public class GenericRepository<TEntity> : RepositoryBase<TEntity>
        where TEntity : EntityBase
    {
    }
}