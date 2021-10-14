using System.Threading.Tasks;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.DeleteIndividual.Interactors
{
    public interface IDeleteIndividualInteractor
    {
        Task ExecuteAsync(long individualId);
    }
}