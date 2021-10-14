using System;
using System.Threading.Tasks;
using Mmu.Cca.Bc.Base.DomainModels.Models;
using Mmu.Cca.Bc.Base.DomainServices.Repositories;

namespace Mmu.Cca.Bc.Base.DomainServices.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetGenericRepository<TEntity>()
            where TEntity : EntityBase;

        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}