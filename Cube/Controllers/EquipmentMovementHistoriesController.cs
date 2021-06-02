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
    public class EquipmentMovementHistoriesController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public EquipmentMovementHistoriesController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentMovementHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentMovementHistory>>> GetEquipmentMovementHistories()
        {
            return await _context.EquipmentMovementHistories.ToListAsync();
        }

        // GET: api/EquipmentMovementHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentMovementHistory>> GetEquipmentMovementHistory(long id)
        {
            var equipmentMovementHistory = await _context.EquipmentMovementHistories.FindAsync(id);

            if (equipmentMovementHistory == null)
            {
                return NotFound();
            }

            return equipmentMovementHistory;
        }

        // PUT: api/EquipmentMovementHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentMovementHistory(long id, EquipmentMovementHistory equipmentMovementHistory)
        {
            if (id != equipmentMovementHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentMovementHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentMovementHistoryExists(id))
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

        // POST: api/EquipmentMovementHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentMovementHistory>> PostEquipmentMovementHistory(EquipmentMovementHistory equipmentMovementHistory)
        {
            _context.EquipmentMovementHistories.Add(equipmentMovementHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentMovementHistory", new { id = equipmentMovementHistory.Id }, equipmentMovementHistory);
        }

        // DELETE: api/EquipmentMovementHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentMovementHistory(long id)
        {
            var equipmentMovementHistory = await _context.EquipmentMovementHistories.FindAsync(id);
            if (equipmentMovementHistory == null)
            {
                return NotFound();
            }

            _context.EquipmentMovementHistories.Remove(equipmentMovementHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentMovementHistoryExists(long id)
        {
            return _context.EquipmentMovementHistories.Any(e => e.Id == id);
        }
    }
}
