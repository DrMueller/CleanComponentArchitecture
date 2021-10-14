using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Mmu.Cca.CrossCutting.Areas.Settings.Services;
using Mmu.Cca.DataAccess.Areas.DbContexts.Contexts;
using Mmu.Cca.DataAccess.Areas.DbContexts.Contexts.Implementation;
using Mmu.Cca.DataAccess.Areas.TypeConfigurations.Base;

namespace Mmu.Cca.DataAccess.Areas.DbContexts.Factories.Implementation
{
    public class AppDbContextFactory : IAppDbContextFactory
    {
        private readonly IAppSettingsProvider _appSettingsProvider;
        private readonly Lazy<DbContextOptions> _lazyOptions;

        public AppDbContextFactory(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
            _lazyOptions = new Lazy<DbContextOptions>(CreateDbContextOptions);
        }

        public IAppDbContext Create()
        {
            return new AppDbContext(_lazyOptions.Value);
        }

        private DbContextOptions CreateDbContextOptions()
        {
            var configuration = SqlServerConventionSetBuilder.Build();
            var mb = new ModelBuilder(configuration);
            var entityConfigAssembly = typeof(EntityConfigBase<>).Assembly;
            mb.ApplyConfigurationsFromAssembly(entityConfigAssembly);
            mb.FinalizeModel();

            return new DbContextOptionsBuilder()
                .UseSqlServer(_appSettingsProvider.Settings.ConnectionString)
                .UseModel(mb.Model)
                .Options;
        }
    }
}