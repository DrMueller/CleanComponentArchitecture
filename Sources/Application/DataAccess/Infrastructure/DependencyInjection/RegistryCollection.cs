using JetBrains.Annotations;
using Lamar;
using Mmu.Cca.Bc.Base.DomainServices.Querying.Services;
using Mmu.Cca.Bc.Base.DomainServices.Repositories;
using Mmu.Cca.Bc.Base.DomainServices.UnitOfWorks;
using Mmu.Cca.DataAccess.Areas.DbContexts.Contexts.Implementation;
using Mmu.Cca.DataAccess.Areas.DbContexts.Factories;
using Mmu.Cca.DataAccess.Areas.DbContexts.Factories.Implementation;
using Mmu.Cca.DataAccess.Areas.Querying.Services.Implementation;
using Mmu.Cca.DataAccess.Areas.Repositories.Generic.Implementation;
using Mmu.Cca.DataAccess.Areas.UnitOfWorks.Implementation;
using Mmu.Cca.DataAccess.Areas.UnitOfWorks.Servants;
using Mmu.Cca.DataAccess.Areas.UnitOfWorks.Servants.Implementation;

namespace Mmu.Cca.DataAccess.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<RegistryCollection>();
                    scanner.AddAllTypesOf<IRepository>();
                    scanner.Exclude(type => type == typeof(AppDbContext));
                    scanner.WithDefaultConventions();
                });

            For(typeof(IRepository<>)).Use(typeof(GenericRepository<>)).Transient();
            For<IRepositoryCache>().Use<RepositoryCache>().Transient();

            For<IAppDbContextFactory>().Use<AppDbContextFactory>().Singleton();
            For<IUnitOfWorkFactory>().Use<UnitOfWorkFactory>().Singleton();
            For<IQueryService>().Use<QueryService>().Singleton();
            For<IUnitOfWork>().Use<UnitOfWork>().Transient();
        }
    }
}