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
    public class StatusesController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public StatusesController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/Statuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statuse>>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statuse>> GetStatuse(long id)
        {
            var statuse = await _context.Statuses.FindAsync(id);

            if (statuse == null)
            {
                return NotFound();
            }

            return statuse;
        }

        // PUT: api/Statuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatuse(long id, Statuse statuse)
        {
            if (id != statuse.Id)
            {
                return BadRequest();
            }

            _context.Entry(statuse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatuseExists(id))
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

        // POST: api/Statuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Statuse>> PostStatuse(Statuse statuse)
        {
            _context.Statuses.Add(statuse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatuse", new { id = statuse.Id }, statuse);
        }

        // DELETE: api/Statuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatuse(long id)
        {
            var statuse = await _context.Statuses.FindAsync(id);
            if (statuse == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(statuse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatuseExists(long id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }
    }
}
