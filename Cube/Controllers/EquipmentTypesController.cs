﻿using System;
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
    public class EquipmentTypesController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public EquipmentTypesController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentType>>> GetEquipmentTypes()
        {
            return await _context.EquipmentTypes.ToListAsync();
        }

        // GET: api/EquipmentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentType>> GetEquipmentType(long id)
        {
            var equipmentType = await _context.EquipmentTypes.FindAsync(id);

            if (equipmentType == null)
            {
                return NotFound();
            }

            return equipmentType;
        }

        // PUT: api/EquipmentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentType(long id, EquipmentType equipmentType)
        {
            if (id != equipmentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentTypeExists(id))
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

        // POST: api/EquipmentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentType>> PostEquipmentType(EquipmentType equipmentType)
        {
            _context.EquipmentTypes.Add(equipmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentType", new { id = equipmentType.Id }, equipmentType);
        }

        // DELETE: api/EquipmentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentType(long id)
        {
            var equipmentType = await _context.EquipmentTypes.FindAsync(id);
            if (equipmentType == null)
            {
                return NotFound();
            }

            _context.EquipmentTypes.Remove(equipmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentTypeExists(long id)
        {
            return _context.EquipmentTypes.Any(e => e.Id == id);
        }
    }
}
