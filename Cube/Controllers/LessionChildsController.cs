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
    public class LessionChildsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public LessionChildsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/LessionChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessionChild>>> GetLessionChilds()
        {
            return await _context.LessionChilds.ToListAsync();
        }

        // GET: api/LessionChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LessionChild>> GetLessionChild(long id)
        {
            var lessionChild = await _context.LessionChilds.FindAsync(id);

            if (lessionChild == null)
            {
                return NotFound();
            }

            return lessionChild;
        }

        // PUT: api/LessionChilds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLessionChild(long id, LessionChild lessionChild)
        {
            if (id != lessionChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(lessionChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessionChildExists(id))
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

        // POST: api/LessionChilds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LessionChild>> PostLessionChild(LessionChild lessionChild)
        {
            _context.LessionChilds.Add(lessionChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLessionChild", new { id = lessionChild.Id }, lessionChild);
        }

        // DELETE: api/LessionChilds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLessionChild(long id)
        {
            var lessionChild = await _context.LessionChilds.FindAsync(id);
            if (lessionChild == null)
            {
                return NotFound();
            }

            _context.LessionChilds.Remove(lessionChild);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessionChildExists(long id)
        {
            return _context.LessionChilds.Any(e => e.Id == id);
        }
    }
}
