using System.Threading.Tasks;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadFirstIndividualWithRoles.Dtos;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadFirstIndividualWithRoles.Interactors
{
    public interface ILoadFirstIndividualWithRolesInteractor
    {
        Task<IndividualWithRolesDto> ExecuteAsync();
    }
}