using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.Cca.Bc.Organisations.Areas.UseCases.LoadAllOrganisations.Dtos;
using Mmu.Cca.Bc.Organisations.Areas.UseCases.LoadAllOrganisations.Interactors;

namespace Mmu.Cca.WebApi.Areas.Organisations.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrganisationsController : ControllerBase
    {
        private readonly ILoadAllOrganisationsInteractor _loadAllOrgsInteractor;

        public OrganisationsController(ILoadAllOrganisationsInteractor loadAllOrgsInteractor)
        {
            _loadAllOrgsInteractor = loadAllOrgsInteractor;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<OrganisationDto>>> LoadAllAsync()
        {
            var allDtos = await _loadAllOrgsInteractor.ExecuteAsync();

            return Ok(allDtos);
        }
    }
}