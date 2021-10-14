using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mmu.Cca.Bc.Base.DomainModels.Specs;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadFirstIndividualWithRoles.Specs
{
    public class LoadIndividualsWithRolesSpec : ISpecification<Individual>
    {
        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry
                .Include(f => f.Roles)
                .Where(f => f.Roles.Any());
        }
    }
}