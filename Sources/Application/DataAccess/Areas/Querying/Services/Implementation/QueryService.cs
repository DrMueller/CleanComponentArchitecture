using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Base.DomainModels.Specs;
using Mmu.Cca.Bc.Base.DomainServices.Querying.Services;
using Mmu.Cca.DataAccess.Areas.DbContexts.Contexts;
using Mmu.Cca.DataAccess.Areas.DbContexts.Factories;

namespace Mmu.Cca.DataAccess.Areas.Querying.Services.Implementation
{
    public class QueryService : IQueryService
    {
        private readonly IAppDbContext _appDbContext;

        public QueryService(IAppDbContextFactory appDbContextFactory)
        {
            _appDbContext = appDbContextFactory.Create();
        }

        public async Task<IReadOnlyCollection<TResult>> QueryAsync<TEntity, TResult>(ISpecification<TEntity, TResult> spec) where TEntity : EntityBase
        {
            var dbSet = _appDbContext.Set<TEntity>().AsNoTracking();

            var query = spec.Apply(dbSet);

            var selectSet = query.Select(spec.Selector);
            var result = await selectSet.ToListAsync();

            return result;
        }

        public async Task<IReadOnlyCollection<TEntity>> QueryAsync<TEntity>(ISpecification<TEntity> spec) where TEntity : EntityBase
        {
            var dbSet = _appDbContext.Set<TEntity>().AsNoTracking();
            var query = spec.Apply(dbSet);

            var result = await query.ToListAsync();

            return result;
        }
    }
}