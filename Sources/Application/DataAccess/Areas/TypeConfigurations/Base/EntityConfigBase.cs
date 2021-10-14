using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.Cca.Bc.Base.DomainModels.Models;

namespace Mmu.Cca.DataAccess.Areas.TypeConfigurations.Base
{
    public abstract class EntityConfigBase<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(f => f.UpdatedDate).IsRequired();
            builder.Property(f => f.CreatedDate).IsRequired();

            ConfigureEntity(builder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}