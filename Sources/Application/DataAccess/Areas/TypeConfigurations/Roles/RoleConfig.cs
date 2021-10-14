using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.Cca.Bc.Shared.Areas.DomainModels.Models.Roles;
using Mmu.Cca.DataAccess.Areas.TypeConfigurations.Base;

namespace Mmu.Cca.DataAccess.Areas.TypeConfigurations.Roles
{
    public class RoleConfig : EntityConfigBase<Role>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.Property(f => f.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(role => role.Individual)
                .WithMany(ind => ind.Roles)
                .IsRequired();

            builder.HasOne(role => role.Organisation)
                .WithMany(org => org.Roles)
                .IsRequired();

            builder.ToTable(nameof(Role), Schemas.Roles);
        }
    }
}