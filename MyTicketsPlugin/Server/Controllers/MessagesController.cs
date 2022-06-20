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
    public class MessagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _unitOfWork.Messages.GetAll(includes: q => q.Include(x => x.Ticket));
            return Ok(messages);

        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var message = await _unitOfWork.Messages.Get(q => q.msgId == id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.msgId)
            {
                return BadRequest();
            }
            _unitOfWork.Messages.Update(message);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MessageExists(id))
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


        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostMessage(Message message)
        {
            await _unitOfWork.Messages.Insert(message);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMessage", new { id = message.msgId }, message);

        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _unitOfWork.Messages.Get(q => q.msgId == id);

            if (message == null)
            {
                return NotFound();
            }

            await _unitOfWork.Messages.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }


        private async Task<bool> MessageExists(int id)
        {
            var message = await _unitOfWork.Messages.Get(q => q.msgId == id);
            return message != null;
        }
    }
}
