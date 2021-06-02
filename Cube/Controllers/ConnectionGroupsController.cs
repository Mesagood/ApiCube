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
    public class ConnectionGroupsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public ConnectionGroupsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/ConnectionGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConnectionGroup>>> GetConnectionGroups()
        {
            return await _context.ConnectionGroups.ToListAsync();
        }

        // GET: api/ConnectionGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConnectionGroup>> GetConnectionGroup(long id)
        {
            var connectionGroup = await _context.ConnectionGroups.FindAsync(id);

            if (connectionGroup == null)
            {
                return NotFound();
            }

            return connectionGroup;
        }

        // PUT: api/ConnectionGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConnectionGroup(long id, ConnectionGroup connectionGroup)
        {
            if (id != connectionGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(connectionGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionGroupExists(id))
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

        // POST: api/ConnectionGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConnectionGroup>> PostConnectionGroup(ConnectionGroup connectionGroup)
        {
            _context.ConnectionGroups.Add(connectionGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConnectionGroup", new { id = connectionGroup.Id }, connectionGroup);
        }

        // DELETE: api/ConnectionGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConnectionGroup(long id)
        {
            var connectionGroup = await _context.ConnectionGroups.FindAsync(id);
            if (connectionGroup == null)
            {
                return NotFound();
            }

            _context.ConnectionGroups.Remove(connectionGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConnectionGroupExists(long id)
        {
            return _context.ConnectionGroups.Any(e => e.Id == id);
        }
    }
}
