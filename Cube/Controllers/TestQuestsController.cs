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
    public class TestQuestsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public TestQuestsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/TestQuests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestQuest>>> GetTestQuests()
        {
            return await _context.TestQuests.ToListAsync();
        }

        // GET: api/TestQuests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestQuest>> GetTestQuest(long id)
        {
            var testQuest = await _context.TestQuests.FindAsync(id);

            if (testQuest == null)
            {
                return NotFound();
            }

            return testQuest;
        }

        // PUT: api/TestQuests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestQuest(long id, TestQuest testQuest)
        {
            if (id != testQuest.Id)
            {
                return BadRequest();
            }

            _context.Entry(testQuest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestQuestExists(id))
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

        // POST: api/TestQuests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestQuest>> PostTestQuest(TestQuest testQuest)
        {
            _context.TestQuests.Add(testQuest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestQuest", new { id = testQuest.Id }, testQuest);
        }

        // DELETE: api/TestQuests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestQuest(long id)
        {
            var testQuest = await _context.TestQuests.FindAsync(id);
            if (testQuest == null)
            {
                return NotFound();
            }

            _context.TestQuests.Remove(testQuest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestQuestExists(long id)
        {
            return _context.TestQuests.Any(e => e.Id == id);
        }
    }
}
