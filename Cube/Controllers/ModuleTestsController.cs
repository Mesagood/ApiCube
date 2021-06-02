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
    public class ModuleTestsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public ModuleTestsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/ModuleTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleTest>>> GetModuleTests()
        {
            return await _context.ModuleTests.ToListAsync();
        }

        // GET: api/ModuleTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleTest>> GetModuleTest(long id)
        {
            var moduleTest = await _context.ModuleTests.FindAsync(id);

            if (moduleTest == null)
            {
                return NotFound();
            }

            return moduleTest;
        }

        // PUT: api/ModuleTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModuleTest(long id, ModuleTest moduleTest)
        {
            if (id != moduleTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(moduleTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleTestExists(id))
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

        // POST: api/ModuleTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModuleTest>> PostModuleTest(ModuleTest moduleTest)
        {
            _context.ModuleTests.Add(moduleTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModuleTest", new { id = moduleTest.Id }, moduleTest);
        }

        // DELETE: api/ModuleTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModuleTest(long id)
        {
            var moduleTest = await _context.ModuleTests.FindAsync(id);
            if (moduleTest == null)
            {
                return NotFound();
            }

            _context.ModuleTests.Remove(moduleTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuleTestExists(long id)
        {
            return _context.ModuleTests.Any(e => e.Id == id);
        }
    }
}
