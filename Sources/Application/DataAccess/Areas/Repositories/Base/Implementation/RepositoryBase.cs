using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Base.DomainModels.Specs;
using Mmu.Cca.Bc.Base.DomainServices.Repositories;
using Mmu.Cca.DataAccess.Areas.DbContexts.Contexts;

namespace Mmu.Cca.DataAccess.Areas.Repositories.Base.Implementation
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase, IRepository<TEntity>
        where TEntity : EntityBase
    {
        protected DbSet<TEntity> DbSet { get; private set; }

        public async Task DeleteAsync(long id)
        {
            var loadedEntity = await DbSet.SingleOrDefaultAsync(f => f.Id == id);

            if (loadedEntity == null)
            {
                return;
            }

            DbSet.Remove(loadedEntity);
        }

        public Task DeleteAsync(ISpecification<TEntity> spec)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<TEntity>> LoadAllAsync(ISpecification<TEntity> spec)
        {
            var qry = spec.Apply(DbSet);

            return await qry.ToListAsync();
        }

        public async Task<TEntity> LoadAsync(ISpecification<TEntity> spec)
        {
            var qry = spec.Apply(DbSet);

            return await qry.SingleOrDefaultAsync();
        }

        public async Task UpsertAsync(TEntity entity)
        {
            if (entity.Id.Equals(default))
            {
                await DbSet.AddAsync(entity);
            }
            else
            {
                DbSet.Update(entity);
            }
        }

        public async Task UpsertRangeAsync(IReadOnlyCollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await UpsertAsync(entity);
            }
        }

        void IRepositoryBase.Initialize(IAppDbContext dbContext)
        {
            DbSet = dbContext.Set<TEntity>();
        }
    }
}