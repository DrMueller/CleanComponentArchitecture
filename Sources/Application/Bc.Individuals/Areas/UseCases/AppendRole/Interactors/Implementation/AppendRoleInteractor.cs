using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainServices.UnitOfWorks;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.AppendRole.Dto;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.AppendRole.Specs;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Individuals;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Organisations;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Roles;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.AppendRole.Interactors.Implementation
{
    public class AppendRoleInteractor : IAppendRoleInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public AppendRoleInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long individualId, AppendRoleRequestDto dto)
        {
            using var uow = _uowFactory.Create();

            var indRepo = uow.GetGenericRepository<Individual>();
            var spec = new LoadIndividualWithRolesSpec(individualId);
            var individual = await indRepo.LoadAsync(spec);

            individual.Roles.Add(
                new Role
                {
                    Description = dto.RoleDescription,
                    Organisation = new Organisation
                    {
                        Name = dto.OrganisationName
                    }
                });

            await uow.SaveAsync();
        }
    }
}