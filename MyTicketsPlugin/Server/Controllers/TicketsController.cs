using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTicketsPlugin.Server.Data;
using MyTicketsPlugin.Server.IRepository;
using MyTicketsPlugin.Shared.Domain;

namespace MyTicketsPlugin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Categorias
        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _unitOfWork.Tickets.GetAll(includes: q => q.Include(x => x.Categoria).Include(x => x.Estadoticket));
            return Ok(tickets);

        }

        // GET: /Categorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _unitOfWork.Tickets.Get(q => q.ticketId == id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // GET: /Categorias/5/details
        [HttpGet("{id}/{details}")]
        public async Task<IActionResult> GetTicketDetails(int id)
        {
            var ticket = await _unitOfWork.Tickets.Get(q => q.ticketId == id,
                includes: q => q.Include(x => x.Categoria).Include(x => x.Estadoticket));

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // PUT: /Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTickets(int id, Ticket ticket)
        {
            if (id != ticket.ticketId)
            {
                return BadRequest();
            }
            _unitOfWork.Tickets.Update(ticket);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //POST: /Categorias
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTickets(Ticket ticket)
        {
            await _unitOfWork.Tickets.Insert(ticket);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTicket", new { id = ticket.ticketId }, ticket);

        }

        // DELETE: /Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _unitOfWork.Tickets.Get(q => q.ticketId == id);
            if (ticket == null)
            {
                return NotFound();
            }
            await _unitOfWork.Tickets.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> TicketExists(int id)
        {
            var ticket = await _unitOfWork.Tickets.Get(q => q.ticketId == id);
            return ticket != null;
        }
    }
}
