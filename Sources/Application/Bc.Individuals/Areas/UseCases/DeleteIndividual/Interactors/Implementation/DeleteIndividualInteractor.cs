using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainServices.UnitOfWorks;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.DeleteIndividual.Interactors.Implementation
{
    public class DeleteIndividualInteractor : IDeleteIndividualInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public DeleteIndividualInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long individualId)
        {
            using var uow = _uowFactory.Create();

            var indRepo = uow.GetGenericRepository<Individual>();
            await indRepo.DeleteAsync(individualId);

            await uow.SaveAsync();
        }
    }
}