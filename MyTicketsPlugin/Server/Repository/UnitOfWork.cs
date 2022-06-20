using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTicketsPlugin.Server.Data;
using MyTicketsPlugin.Server.IRepository;
using MyTicketsPlugin.Server.Models;
using MyTicketsPlugin.Shared.Domain;
using System.Security.Claims;

namespace MyTicketsPlugin.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<_File> _files;
        private IGenericRepository<Categoria> _categorias;
        private IGenericRepository<Estadoticket> _estadoTickets;
        private IGenericRepository<Message> _messages;
        private IGenericRepository<Ticket> _tickets;

        private UserManager<ApplicationUser> _userManager;
        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<_File> Files
            => _files ??= new GenericRepository<_File>(_context);
        public IGenericRepository<Categoria> Categorias
            => _categorias ??= new GenericRepository<Categoria>(_context);
        public IGenericRepository<Estadoticket> Estadotickets
            => _estadoTickets ??= new GenericRepository<Estadoticket>(_context);
        public IGenericRepository<Message> Messages
            => _messages ??= new GenericRepository<Message>(_context);
        public IGenericRepository<Ticket> Tickets
            => _tickets ??= new GenericRepository<Ticket>(_context);
       

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            await _context.SaveChangesAsync();
        }
    }
}
