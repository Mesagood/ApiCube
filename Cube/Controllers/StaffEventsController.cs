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
    public class StaffEventsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public StaffEventsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/StaffEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffEvent>>> GetStaffEvents()
        {
            return await _context.StaffEvents.ToListAsync();
        }

        // GET: api/StaffEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffEvent>> GetStaffEvent(long id)
        {
            var staffEvent = await _context.StaffEvents.FindAsync(id);

            if (staffEvent == null)
            {
                return NotFound();
            }

            return staffEvent;
        }

        // PUT: api/StaffEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffEvent(long id, StaffEvent staffEvent)
        {
            if (id != staffEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(staffEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffEventExists(id))
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

        // POST: api/StaffEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffEvent>> PostStaffEvent(StaffEvent staffEvent)
        {
            _context.StaffEvents.Add(staffEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffEvent", new { id = staffEvent.Id }, staffEvent);
        }

        // DELETE: api/StaffEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffEvent(long id)
        {
            var staffEvent = await _context.StaffEvents.FindAsync(id);
            if (staffEvent == null)
            {
                return NotFound();
            }

            _context.StaffEvents.Remove(staffEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffEventExists(long id)
        {
            return _context.StaffEvents.Any(e => e.Id == id);
        }
    }
}
