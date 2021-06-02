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
    public class LessionsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public LessionsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/Lessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lession>>> GetLessions()
        {
            return await _context.Lessions.ToListAsync();
        }

        // GET: api/Lessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lession>> GetLession(long id)
        {
            var lession = await _context.Lessions.FindAsync(id);

            if (lession == null)
            {
                return NotFound();
            }

            return lession;
        }

        // PUT: api/Lessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLession(long id, Lession lession)
        {
            if (id != lession.Id)
            {
                return BadRequest();
            }

            _context.Entry(lession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessionExists(id))
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

        // POST: api/Lessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lession>> PostLession(Lession lession)
        {
            _context.Lessions.Add(lession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLession", new { id = lession.Id }, lession);
        }

        // DELETE: api/Lessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLession(long id)
        {
            var lession = await _context.Lessions.FindAsync(id);
            if (lession == null)
            {
                return NotFound();
            }

            _context.Lessions.Remove(lession);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessionExists(long id)
        {
            return _context.Lessions.Any(e => e.Id == id);
        }
    }
}
