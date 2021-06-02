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
    public class EquipmentGroupsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public EquipmentGroupsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentGroup>>> GetEquipmentGroups()
        {
            return await _context.EquipmentGroups.ToListAsync();
        }

        // GET: api/EquipmentGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentGroup>> GetEquipmentGroup(long id)
        {
            var equipmentGroup = await _context.EquipmentGroups.FindAsync(id);

            if (equipmentGroup == null)
            {
                return NotFound();
            }

            return equipmentGroup;
        }

        // PUT: api/EquipmentGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentGroup(long id, EquipmentGroup equipmentGroup)
        {
            if (id != equipmentGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentGroupExists(id))
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

        // POST: api/EquipmentGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentGroup>> PostEquipmentGroup(EquipmentGroup equipmentGroup)
        {
            _context.EquipmentGroups.Add(equipmentGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentGroup", new { id = equipmentGroup.Id }, equipmentGroup);
        }

        // DELETE: api/EquipmentGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentGroup(long id)
        {
            var equipmentGroup = await _context.EquipmentGroups.FindAsync(id);
            if (equipmentGroup == null)
            {
                return NotFound();
            }

            _context.EquipmentGroups.Remove(equipmentGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentGroupExists(long id)
        {
            return _context.EquipmentGroups.Any(e => e.Id == id);
        }
    }
}
