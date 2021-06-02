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
    public class GroupChildsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public GroupChildsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/GroupChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupChild>>> GetGroupChilds()
        {
            return await _context.GroupChilds.ToListAsync();
        }

        // GET: api/GroupChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupChild>> GetGroupChild(long id)
        {
            var groupChild = await _context.GroupChilds.FindAsync(id);

            if (groupChild == null)
            {
                return NotFound();
            }

            return groupChild;
        }

        // PUT: api/GroupChilds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupChild(long id, GroupChild groupChild)
        {
            if (id != groupChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupChildExists(id))
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

        // POST: api/GroupChilds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupChild>> PostGroupChild(GroupChild groupChild)
        {
            _context.GroupChilds.Add(groupChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupChild", new { id = groupChild.Id }, groupChild);
        }

        // DELETE: api/GroupChilds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupChild(long id)
        {
            var groupChild = await _context.GroupChilds.FindAsync(id);
            if (groupChild == null)
            {
                return NotFound();
            }

            _context.GroupChilds.Remove(groupChild);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupChildExists(long id)
        {
            return _context.GroupChilds.Any(e => e.Id == id);
        }
    }
}
