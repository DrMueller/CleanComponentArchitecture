using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Base.DomainModels.Specs;

namespace Mmu.Cca.Bc.Base.DomainServices.Repositories
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface for easier generic handling")]
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository
        where TEntity : EntityBase
    {
        Task DeleteAsync(long id);

        Task<IReadOnlyCollection<TEntity>> LoadAllAsync(ISpecification<TEntity> spec);

        Task<TEntity> LoadAsync(ISpecification<TEntity> spec);

        Task UpsertAsync(TEntity entity);
    }
}