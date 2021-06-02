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
    public class EquipmentStatusesController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public EquipmentStatusesController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentStatuse>>> GetEquipmentStatuses()
        {
            return await _context.EquipmentStatuses.ToListAsync();
        }

        // GET: api/EquipmentStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentStatuse>> GetEquipmentStatuse(long id)
        {
            var equipmentStatuse = await _context.EquipmentStatuses.FindAsync(id);

            if (equipmentStatuse == null)
            {
                return NotFound();
            }

            return equipmentStatuse;
        }

        // PUT: api/EquipmentStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentStatuse(long id, EquipmentStatuse equipmentStatuse)
        {
            if (id != equipmentStatuse.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentStatuse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentStatuseExists(id))
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

        // POST: api/EquipmentStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentStatuse>> PostEquipmentStatuse(EquipmentStatuse equipmentStatuse)
        {
            _context.EquipmentStatuses.Add(equipmentStatuse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentStatuse", new { id = equipmentStatuse.Id }, equipmentStatuse);
        }

        // DELETE: api/EquipmentStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentStatuse(long id)
        {
            var equipmentStatuse = await _context.EquipmentStatuses.FindAsync(id);
            if (equipmentStatuse == null)
            {
                return NotFound();
            }

            _context.EquipmentStatuses.Remove(equipmentStatuse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentStatuseExists(long id)
        {
            return _context.EquipmentStatuses.Any(e => e.Id == id);
        }
    }
}
