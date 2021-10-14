using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mmu.Cca.Bc.Base.DomainModels.Specs;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.AppendRole.Specs
{
    public class LoadIndividualWithRolesSpec : ISpecification<Individual>
    {
        private readonly long _individualId;

        public LoadIndividualWithRolesSpec(long individualId)
        {
            _individualId = individualId;
        }

        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry
                .Include(f => f.Roles)
                .Where(f => f.Id == _individualId);
        }
    }
}