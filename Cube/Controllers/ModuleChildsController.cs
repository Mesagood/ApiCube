using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cube;
using Cube.Models;

namespace Cube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleChildsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public ModuleChildsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/ModuleChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleChild>>> GetModuleChilds()
        {
            return await _context.ModuleChilds.ToListAsync();
        }

        // GET: api/ModuleChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleChild>> GetModuleChild(long id)
        {
            var moduleChild = await _context.ModuleChilds.FindAsync(id);

            if (moduleChild == null)
            {
                return NotFound();
            }

            return moduleChild;
        }

        // PUT: api/ModuleChilds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModuleChild(long id, ModuleChild moduleChild)
        {
            if (id != moduleChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(moduleChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleChildExists(id))
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

        // POST: api/ModuleChilds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModuleChild>> PostModuleChild(ModuleChild moduleChild)
        {
            _context.ModuleChilds.Add(moduleChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModuleChild", new { id = moduleChild.Id }, moduleChild);
        }

        // DELETE: api/ModuleChilds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModuleChild(long id)
        {
            var moduleChild = await _context.ModuleChilds.FindAsync(id);
            if (moduleChild == null)
            {
                return NotFound();
            }

            _context.ModuleChilds.Remove(moduleChild);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuleChildExists(long id)
        {
            return _context.ModuleChilds.Any(e => e.Id == id);
        }
    }
}
