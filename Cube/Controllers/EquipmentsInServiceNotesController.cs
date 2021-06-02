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
    public class EquipmentsInServiceNotesController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public EquipmentsInServiceNotesController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentsInServiceNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentsInServiceNote>>> GetEquipmentsInServiceNotes()
        {
            return await _context.EquipmentsInServiceNotes.ToListAsync();
        }

        // GET: api/EquipmentsInServiceNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentsInServiceNote>> GetEquipmentsInServiceNote(long id)
        {
            var equipmentsInServiceNote = await _context.EquipmentsInServiceNotes.FindAsync(id);

            if (equipmentsInServiceNote == null)
            {
                return NotFound();
            }

            return equipmentsInServiceNote;
        }

        // PUT: api/EquipmentsInServiceNotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentsInServiceNote(long id, EquipmentsInServiceNote equipmentsInServiceNote)
        {
            if (id != equipmentsInServiceNote.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentsInServiceNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentsInServiceNoteExists(id))
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

        // POST: api/EquipmentsInServiceNotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentsInServiceNote>> PostEquipmentsInServiceNote(EquipmentsInServiceNote equipmentsInServiceNote)
        {
            _context.EquipmentsInServiceNotes.Add(equipmentsInServiceNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentsInServiceNote", new { id = equipmentsInServiceNote.Id }, equipmentsInServiceNote);
        }

        // DELETE: api/EquipmentsInServiceNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentsInServiceNote(long id)
        {
            var equipmentsInServiceNote = await _context.EquipmentsInServiceNotes.FindAsync(id);
            if (equipmentsInServiceNote == null)
            {
                return NotFound();
            }

            _context.EquipmentsInServiceNotes.Remove(equipmentsInServiceNote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentsInServiceNoteExists(long id)
        {
            return _context.EquipmentsInServiceNotes.Any(e => e.Id == id);
        }
    }
}
