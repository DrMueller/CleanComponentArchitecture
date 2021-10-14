using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Organisations;
using Mmu.Cca.DataAccess.Areas.TypeConfigurations.Base;

namespace Mmu.Cca.DataAccess.Areas.TypeConfigurations.Organisations
{
    public class OrganisationConfig : EntityConfigBase<Organisation>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Organisation> builder)
        {
            builder.Property(f => f.Name).HasMaxLength(100).IsRequired();
            builder.ToTable(nameof(Organisation), Schemas.Organisations);
        }
    }
}