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
    public class LessionEmployeesController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public LessionEmployeesController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/LessionEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessionEmployee>>> GetLessionEmployees()
        {
            return await _context.LessionEmployees.ToListAsync();
        }

        // GET: api/LessionEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LessionEmployee>> GetLessionEmployee(long id)
        {
            var lessionEmployee = await _context.LessionEmployees.FindAsync(id);

            if (lessionEmployee == null)
            {
                return NotFound();
            }

            return lessionEmployee;
        }

        // PUT: api/LessionEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLessionEmployee(long id, LessionEmployee lessionEmployee)
        {
            if (id != lessionEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(lessionEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessionEmployeeExists(id))
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

        // POST: api/LessionEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LessionEmployee>> PostLessionEmployee(LessionEmployee lessionEmployee)
        {
            _context.LessionEmployees.Add(lessionEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLessionEmployee", new { id = lessionEmployee.Id }, lessionEmployee);
        }

        // DELETE: api/LessionEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLessionEmployee(long id)
        {
            var lessionEmployee = await _context.LessionEmployees.FindAsync(id);
            if (lessionEmployee == null)
            {
                return NotFound();
            }

            _context.LessionEmployees.Remove(lessionEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessionEmployeeExists(long id)
        {
            return _context.LessionEmployees.Any(e => e.Id == id);
        }
    }
}
