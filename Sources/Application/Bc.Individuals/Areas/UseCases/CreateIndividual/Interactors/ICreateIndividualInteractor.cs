using System.Threading.Tasks;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.CreateIndividual.Dtos;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.CreateIndividual.Interactors
{
    public interface ICreateIndividualInteractor
    {
        Task<CreateIndividualResultDto> ExecuteAsync(CreateIndividualRequestDto dto);
    }
}