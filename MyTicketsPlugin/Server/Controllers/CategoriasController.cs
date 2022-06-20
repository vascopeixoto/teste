using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTicketsPlugin.Server.Data;
using MyTicketsPlugin.Server.IRepository;
using MyTicketsPlugin.Shared.Domain;

namespace MyTicketsPlugin.Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Categorias
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _unitOfWork.Categorias.GetAll();
            return Ok(categorias);

        }

        // GET: /Categorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _unitOfWork.Categorias.Get(q => q.categoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: /Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.categoriaId)
            {
                return BadRequest();
            }
            _unitOfWork.Categorias.Update(categoria);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoriaExists(id))
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
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            await _unitOfWork.Categorias.Insert(categoria);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCategoria", new { id = categoria.categoriaId }, categoria);

        }

        // DELETE: /Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _unitOfWork.Categorias.Get(q => q.categoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            await _unitOfWork.Categorias.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> CategoriaExists(int id)
        {
            var categoria = await _unitOfWork.Categorias.Get(q => q.categoriaId == id);
            return categoria != null;
        }
    }
}
