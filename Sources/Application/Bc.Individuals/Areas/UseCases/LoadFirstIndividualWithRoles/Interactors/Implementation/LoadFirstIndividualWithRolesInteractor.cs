using System.Linq;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainServices.Querying.Services;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadFirstIndividualWithRoles.Dtos;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadFirstIndividualWithRoles.Specs;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadFirstIndividualWithRoles.Interactors.Implementation
{
    public class LoadFirstIndividualWithRolesInteractor : ILoadFirstIndividualWithRolesInteractor
    {
        private readonly IQueryService _queryService;

        public LoadFirstIndividualWithRolesInteractor(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IndividualWithRolesDto> ExecuteAsync()
        {
            var individuals = await _queryService.QueryAsync(new LoadIndividualsWithRolesSpec());
            var dto = individuals.Select(
                ind => new IndividualWithRolesDto
                {
                    AmountOfRoles = ind.Roles.Count,
                    IndividualId = ind.Id
                }).First();

            return dto;
        }
    }
}