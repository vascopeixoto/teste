using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTicketsPlugin.Shared.Domain;

namespace MyTicketsPlugin.Server.Configurations.Entities
{
    public class EstadoTicketConfiguration : IEntityTypeConfiguration<Estadoticket>
    {
        public void Configure(EntityTypeBuilder<Estadoticket> builder)
        {
            builder.HasData(
                new Estadoticket { id = 1, tipoEstado = "Pendente" },
                new Estadoticket { id = 2, tipoEstado = "Aberto" },
                new Estadoticket { id = 3, tipoEstado = "Fechado" }
                );
        }
    }
}
