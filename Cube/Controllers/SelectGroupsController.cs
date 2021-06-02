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
    public class SelectGroupsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public SelectGroupsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/SelectGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectGroup>>> GetSelectGroups()
        {
            return await _context.SelectGroups.ToListAsync();
        }

        // GET: api/SelectGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SelectGroup>> GetSelectGroup(long id)
        {
            var selectGroup = await _context.SelectGroups.FindAsync(id);

            if (selectGroup == null)
            {
                return NotFound();
            }

            return selectGroup;
        }

        // PUT: api/SelectGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelectGroup(long id, SelectGroup selectGroup)
        {
            if (id != selectGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(selectGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectGroupExists(id))
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

        // POST: api/SelectGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SelectGroup>> PostSelectGroup(SelectGroup selectGroup)
        {
            _context.SelectGroups.Add(selectGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelectGroup", new { id = selectGroup.Id }, selectGroup);
        }

        // DELETE: api/SelectGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelectGroup(long id)
        {
            var selectGroup = await _context.SelectGroups.FindAsync(id);
            if (selectGroup == null)
            {
                return NotFound();
            }

            _context.SelectGroups.Remove(selectGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SelectGroupExists(long id)
        {
            return _context.SelectGroups.Any(e => e.Id == id);
        }
    }
}
