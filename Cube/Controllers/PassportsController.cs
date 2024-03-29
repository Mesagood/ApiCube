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
    public class PassportsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public PassportsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/Passports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passport>>> GetPassports()
        {
            return await _context.Passports.ToListAsync();
        }

        // GET: api/Passports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passport>> GetPassport(long id)
        {
            var passport = await _context.Passports.FindAsync(id);

            if (passport == null)
            {
                return NotFound();
            }

            return passport;
        }

        // PUT: api/Passports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassport(long id, Passport passport)
        {
            if (id != passport.Id)
            {
                return BadRequest();
            }

            _context.Entry(passport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassportExists(id))
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

        // POST: api/Passports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passport>> PostPassport(Passport passport)
        {
            _context.Passports.Add(passport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassport", new { id = passport.Id }, passport);
        }

        // DELETE: api/Passports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassport(long id)
        {
            var passport = await _context.Passports.FindAsync(id);
            if (passport == null)
            {
                return NotFound();
            }

            _context.Passports.Remove(passport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassportExists(long id)
        {
            return _context.Passports.Any(e => e.Id == id);
        }
    }
}
