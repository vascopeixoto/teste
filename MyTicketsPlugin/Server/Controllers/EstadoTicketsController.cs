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
    public class EstadoTicketsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoTicketsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/EstadoTickets
        [HttpGet]
        public async Task<IActionResult> GetEstadoDosTickes()
        {
            var estadoTics = await _unitOfWork.Estadotickets.GetAll();
            return Ok(estadoTics);

        }

        // GET: api/EstadoTickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadoTicket(int id)
        {
            var estadoTic = await _unitOfWork.Estadotickets.Get(q => q.id == id);

            if (estadoTic == null)
            {
                return NotFound();
            }

            return Ok(estadoTic);
        }

        // PUT: api/EstadoTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoTicket(int id, Estadoticket estadoTicket)
        {
            if (id != estadoTicket.id)
            {
                return BadRequest();
            }
            _unitOfWork.Estadotickets.Update(estadoTicket);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EstadoTicketExists(id))
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

        // POST: api/EstadoTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostEstadoTicket(Estadoticket estadoTicket)
        {
            await _unitOfWork.Estadotickets.Insert(estadoTicket);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetEstadoTicket", new { id = estadoTicket.id }, estadoTicket);

        }

        // DELETE: api/EstadoTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoTicket(int id)
        {
            var estadoTicket = await _unitOfWork.Estadotickets.Get(q => q.id == id);

            if (estadoTicket == null)
            {
                return NotFound();
            }

            await _unitOfWork.Estadotickets.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> EstadoTicketExists(int id)
        {
            var estadoTic = await _unitOfWork.Estadotickets.Get(q => q.id == id);
            return estadoTic != null;
        }
    }
}
