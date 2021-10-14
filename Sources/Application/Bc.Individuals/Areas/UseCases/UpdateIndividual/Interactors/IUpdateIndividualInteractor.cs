using System.Threading.Tasks;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.UpdateIndividual.Dtos;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.UpdateIndividual.Interactors
{
    public interface IUpdateIndividualInteractor
    {
        Task ExecuteAsync(long individualId, IndividualToUpdateDto dto);
    }
}
