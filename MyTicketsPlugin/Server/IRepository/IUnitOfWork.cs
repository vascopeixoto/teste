using MyTicketsPlugin.Shared.Domain;

namespace MyTicketsPlugin.Server.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<_File> Files { get; }
        IGenericRepository<Categoria> Categorias { get; }
        IGenericRepository<Estadoticket> Estadotickets { get; }
        IGenericRepository<Message> Messages { get; }
        IGenericRepository<Ticket> Tickets { get; }
    }
}
