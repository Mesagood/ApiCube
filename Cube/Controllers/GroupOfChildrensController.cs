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
    public class GroupOfChildrensController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public GroupOfChildrensController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/GroupOfChildrens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupOfChildren>>> GetGroupOfChilds()
        {
            return await _context.GroupOfChilds.ToListAsync();
        }

        // GET: api/GroupOfChildrens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupOfChildren>> GetGroupOfChildren(long id)
        {
            var groupOfChildren = await _context.GroupOfChilds.FindAsync(id);

            if (groupOfChildren == null)
            {
                return NotFound();
            }

            return groupOfChildren;
        }

        // PUT: api/GroupOfChildrens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupOfChildren(long id, GroupOfChildren groupOfChildren)
        {
            if (id != groupOfChildren.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupOfChildren).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupOfChildrenExists(id))
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

        // POST: api/GroupOfChildrens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupOfChildren>> PostGroupOfChildren(GroupOfChildren groupOfChildren)
        {
            _context.GroupOfChilds.Add(groupOfChildren);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupOfChildren", new { id = groupOfChildren.Id }, groupOfChildren);
        }

        // DELETE: api/GroupOfChildrens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupOfChildren(long id)
        {
            var groupOfChildren = await _context.GroupOfChilds.FindAsync(id);
            if (groupOfChildren == null)
            {
                return NotFound();
            }

            _context.GroupOfChilds.Remove(groupOfChildren);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupOfChildrenExists(long id)
        {
            return _context.GroupOfChilds.Any(e => e.Id == id);
        }
    }
}
