using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainServices.UnitOfWorks;
using Mmu.Cca.Bc.Organisations.Areas.DomainServices.Repositories;
using Mmu.Cca.Bc.Organisations.Areas.UseCases.LoadAllOrganisations.Dtos;

namespace Mmu.Cca.Bc.Organisations.Areas.UseCases.LoadAllOrganisations.Interactors.Implementation
{
    public class LoadAllOrganisationsInteractor : ILoadAllOrganisationsInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public LoadAllOrganisationsInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<IReadOnlyCollection<OrganisationDto>> ExecuteAsync()
        {
            using var uow = _uowFactory.Create();

            var orgRepo = uow.GetRepository<IOrganisationRepository>();
            var allOrgs = await orgRepo.LoadAllAsync();

            var dtos = allOrgs.Select(
                org => new OrganisationDto
                {
                    OrganisationId = org.Id,
                    OrganisationName = org.Name
                }).ToList();

            return dtos;
        }
    }
}