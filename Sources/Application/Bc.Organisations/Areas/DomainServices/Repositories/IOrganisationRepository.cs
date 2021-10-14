using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainServices.Repositories;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Organisations;

namespace Mmu.Cca.Bc.Organisations.Areas.DomainServices.Repositories
{
    public interface IOrganisationRepository : IRepository<Organisation>
    {
        Task<IReadOnlyCollection<Organisation>> LoadAllAsync();
    }
}