using System.Linq;
using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Base.DomainModels.Specs;

namespace Mmu.Cca.Bc.Shared.Areas.DomainModels.Specs
{
    public class EntityByIdSpec<TEntity> : ISpecification<TEntity>
        where TEntity : EntityBase
    {
        private readonly long _entityId;

        public EntityByIdSpec(long entityId)
        {
            _entityId = entityId;
        }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> qry)
        {
            return qry.Where(f => f.Id == _entityId);
        }
    }
}