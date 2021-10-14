using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Base.DomainModels.Specs;

namespace Mmu.Cca.Bc.Base.DomainServices.Querying.Services
{
    public interface IQueryService
    {
        Task<IReadOnlyCollection<TResult>> QueryAsync<TEntity, TResult>(ISpecification<TEntity, TResult> spec)
            where TEntity : EntityBase;

        Task<IReadOnlyCollection<TEntity>> QueryAsync<TEntity>(ISpecification<TEntity> spec)
            where TEntity : EntityBase;
    }
}