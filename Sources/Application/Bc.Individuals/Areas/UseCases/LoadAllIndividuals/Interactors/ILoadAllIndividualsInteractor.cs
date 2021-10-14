using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadAllIndividuals.Dtos;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadAllIndividuals.Interactors
{
    public interface ILoadAllIndividualsInteractor
    {
        Task<IReadOnlyCollection<IndividualResultDto>> ExecuteAsync();
    }
}