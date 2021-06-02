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
    public class ServiceNotesController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public ServiceNotesController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/ServiceNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceNote>>> GetServiceNotes()
        {
            return await _context.ServiceNotes.ToListAsync();
        }

        // GET: api/ServiceNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceNote>> GetServiceNote(long id)
        {
            var serviceNote = await _context.ServiceNotes.FindAsync(id);

            if (serviceNote == null)
            {
                return NotFound();
            }

            return serviceNote;
        }

        // PUT: api/ServiceNotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceNote(long id, ServiceNote serviceNote)
        {
            if (id != serviceNote.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceNoteExists(id))
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

        // POST: api/ServiceNotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceNote>> PostServiceNote(ServiceNote serviceNote)
        {
            _context.ServiceNotes.Add(serviceNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceNote", new { id = serviceNote.Id }, serviceNote);
        }

        // DELETE: api/ServiceNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceNote(long id)
        {
            var serviceNote = await _context.ServiceNotes.FindAsync(id);
            if (serviceNote == null)
            {
                return NotFound();
            }

            _context.ServiceNotes.Remove(serviceNote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceNoteExists(long id)
        {
            return _context.ServiceNotes.Any(e => e.Id == id);
        }
    }
}
