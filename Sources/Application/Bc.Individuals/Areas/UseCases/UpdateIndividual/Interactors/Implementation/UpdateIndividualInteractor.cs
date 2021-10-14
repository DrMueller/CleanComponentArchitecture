using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainServices.UnitOfWorks;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.UpdateIndividual.Dtos;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Specs;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.UpdateIndividual.Interactors.Implementation
{
    public class UpdateIndividualInteractor : IUpdateIndividualInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public UpdateIndividualInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long individualId, IndividualToUpdateDto dto)
        {
            using var uow = _uowFactory.Create();
            var indRepo = uow.GetGenericRepository<Individual>();

            var individualByIdSpec = new EntityByIdSpec<Individual>(individualId);
            var ind = await indRepo.LoadAsync(individualByIdSpec);
            ind.FirstName = dto.NewFirstName;

            await uow.SaveAsync();
        }
    }
}
