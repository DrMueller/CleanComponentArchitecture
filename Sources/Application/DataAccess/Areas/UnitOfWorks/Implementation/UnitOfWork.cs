using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Base.DomainServices.Repositories;
using Mmu.Cca.Bc.Base.DomainServices.UnitOfWorks;
using Mmu.Cca.DataAccess.Areas.DbContexts.Contexts;
using Mmu.Cca.DataAccess.Areas.UnitOfWorks.Servants;

namespace Mmu.Cca.DataAccess.Areas.UnitOfWorks.Implementation
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryCache _repoCache;
        private IAppDbContext _dbContext;

        public UnitOfWork(IRepositoryCache repoCache)
        {
            _repoCache = repoCache;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public IRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : EntityBase
        {
            var repoType = typeof(IRepository<TEntity>);

            return _repoCache.GetRepository<IRepository<TEntity>>(repoType, _dbContext);
        }

        public TRepo GetRepository<TRepo>() where TRepo : IRepository
        {
            var repoType = typeof(TRepo);

            return _repoCache.GetRepository<TRepo>(repoType, _dbContext);
        }

        public void Initialize(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            SetTechnicalFields();
            await _dbContext.SaveChangesAsync();
        }

        private void SetTechnicalFields()
        {
            var entries = _dbContext.ChangeTrackerr
                .Entries()
                .Where(
                    e => e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                ((EntityBase)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityBase)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
        }
    }
}