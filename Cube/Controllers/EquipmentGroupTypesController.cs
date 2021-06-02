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
    public class EquipmentGroupTypesController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public EquipmentGroupTypesController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentGroupTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentGroupType>>> GetEquipmentGroupTypes()
        {
            return await _context.EquipmentGroupTypes.ToListAsync();
        }

        // GET: api/EquipmentGroupTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentGroupType>> GetEquipmentGroupType(long id)
        {
            var equipmentGroupType = await _context.EquipmentGroupTypes.FindAsync(id);

            if (equipmentGroupType == null)
            {
                return NotFound();
            }

            return equipmentGroupType;
        }

        // PUT: api/EquipmentGroupTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentGroupType(long id, EquipmentGroupType equipmentGroupType)
        {
            if (id != equipmentGroupType.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentGroupType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentGroupTypeExists(id))
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

        // POST: api/EquipmentGroupTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentGroupType>> PostEquipmentGroupType(EquipmentGroupType equipmentGroupType)
        {
            _context.EquipmentGroupTypes.Add(equipmentGroupType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentGroupType", new { id = equipmentGroupType.Id }, equipmentGroupType);
        }

        // DELETE: api/EquipmentGroupTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentGroupType(long id)
        {
            var equipmentGroupType = await _context.EquipmentGroupTypes.FindAsync(id);
            if (equipmentGroupType == null)
            {
                return NotFound();
            }

            _context.EquipmentGroupTypes.Remove(equipmentGroupType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentGroupTypeExists(long id)
        {
            return _context.EquipmentGroupTypes.Any(e => e.Id == id);
        }
    }
}
