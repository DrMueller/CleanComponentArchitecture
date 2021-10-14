using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Organisations.Areas.UseCases.LoadAllOrganisations.Dtos;

namespace Mmu.Cca.Bc.Organisations.Areas.UseCases.LoadAllOrganisations.Interactors
{
    public interface ILoadAllOrganisationsInteractor
    {
        Task<IReadOnlyCollection<OrganisationDto>> ExecuteAsync();
    }
}