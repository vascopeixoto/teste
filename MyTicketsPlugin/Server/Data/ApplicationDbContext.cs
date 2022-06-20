using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyTicketsPlugin.Server.Configurations.Entities;
using MyTicketsPlugin.Server.Models;
using MyTicketsPlugin.Shared.Domain;

namespace MyTicketsPlugin.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<_File> Files { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estadoticket> Estadotickes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CategoriaSeedConfiguration());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new EstadoTicketConfiguration());


        }
    }
}