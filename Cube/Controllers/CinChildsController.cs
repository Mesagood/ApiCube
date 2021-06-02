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
    public class CinChildsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public CinChildsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/CinChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinChild>>> GetCinChildrens()
        {
            return await _context.CinChildrens.ToListAsync();
        }

        // GET: api/CinChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CinChild>> GetCinChild(long id)
        {
            var cinChild = await _context.CinChildrens.FindAsync(id);

            if (cinChild == null)
            {
                return NotFound();
            }

            return cinChild;
        }

        // PUT: api/CinChilds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinChild(long id, CinChild cinChild)
        {
            if (id != cinChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(cinChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinChildExists(id))
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

        // POST: api/CinChilds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CinChild>> PostCinChild(CinChild cinChild)
        {
            _context.CinChildrens.Add(cinChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCinChild", new { id = cinChild.Id }, cinChild);
        }

        // DELETE: api/CinChilds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinChild(long id)
        {
            var cinChild = await _context.CinChildrens.FindAsync(id);
            if (cinChild == null)
            {
                return NotFound();
            }

            _context.CinChildrens.Remove(cinChild);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CinChildExists(long id)
        {
            return _context.CinChildrens.Any(e => e.Id == id);
        }
    }
}
