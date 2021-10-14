using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainServices.Querying.Services;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadAllIndividuals.Dtos;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadAllIndividuals.Specs;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.LoadAllIndividuals.Interactors.Implementation
{
    public class LoadAllIndividualsInteractor : ILoadAllIndividualsInteractor
    {
        private readonly IQueryService _queryService;

        public LoadAllIndividualsInteractor(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<IndividualResultDto>> ExecuteAsync()
        {
            var dtos = await _queryService.QueryAsync(new LoadAllIndividualsSpec());

            return dtos;
        }
    }
}