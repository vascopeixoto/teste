using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTicketsPlugin.Shared.Domain;

namespace MyTicketsPlugin.Server.Configurations.Entities
{
    public class CategoriaSeedConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasData(
                new Categoria { categoriaId = 1, categoriaName = "Categoria 1" },
                new Categoria { categoriaId = 2, categoriaName = "Categoria 2" },
                new Categoria { categoriaId = 3, categoriaName = "Categoria 3" }
                );
        }
    }
}
