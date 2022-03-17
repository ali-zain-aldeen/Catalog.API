using Catalog.Repositories.Menus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Repositories.Menus.TypeConfigurations
{
    public class MenuTypeConfigurations : IEntityTypeConfiguration<MenuEntity>
    {
        public void Configure(EntityTypeBuilder<MenuEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}