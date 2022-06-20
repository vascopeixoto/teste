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
    public class _FileController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public _FileController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            this._webHostEnvironment = webHostEnvironment;
            this._httpContextAccessor = httpContextAccessor;
        }

        // GET: api/_File
        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            var files = await _unitOfWork.Files.GetAll();
            return Ok(files);

        }

        // GET: api/_File/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get_File(int id)
        {
            var file = await _unitOfWork.Files.Get(q => q.fileId == id);

            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        // PUT: api/_File/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put_File(int id, _File file)
        {
            if (id != file.fileId)
            {
                return BadRequest();
            }
            _unitOfWork.Files.Update(file);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _FileExists(id))
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

        // POST: api/_File
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> Post_File(_File file)
        {
            if (file.FileContent != null)
            {
                file.fileUrl = CreateFile(file.FileContent, file.fileUrl);
            }

            await _unitOfWork.Files.Insert(file);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("Get_File", new { id = file.fileId }, file);

        }
        

        // DELETE: api/_File/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete_File(int id)
        {
            var file = await _unitOfWork.Files.Get(q => q.fileId == id);

            if (file == null)
            {
                return NotFound();
            }

            await _unitOfWork.Files.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }
        private string CreateFile(byte[] file, string name)
        {
            var url = _httpContextAccessor.HttpContext.Request.Host.Value;
            var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{name}";
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(file, 0, file.Length);
            fileStream.Close();
            return $"https://{url}/uploads/{name}";
        }

        private async Task<bool> _FileExists(int id)
        {
            var file = await _unitOfWork.Files.Get(q => q.fileId == id);
            return file != null;
        }

       

        
    }
}
