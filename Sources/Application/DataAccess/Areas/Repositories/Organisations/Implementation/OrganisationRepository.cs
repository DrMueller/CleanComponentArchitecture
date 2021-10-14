using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.Cca.Bc.Organisations.Areas.DomainServices.Repositories;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Organisations;
using Mmu.Cca.DataAccess.Areas.Repositories.Base.Implementation;

namespace Mmu.Cca.DataAccess.Areas.Repositories.Organisations.Implementation
{
    public class OrganisationRepository : RepositoryBase<Organisation>, IOrganisationRepository
    {
        public async Task<IReadOnlyCollection<Organisation>> LoadAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}