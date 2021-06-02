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
    public class UserInEventsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public UserInEventsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/UserInEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInEvent>>> GetUserInEvents()
        {
            return await _context.UserInEvents.ToListAsync();
        }

        // GET: api/UserInEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInEvent>> GetUserInEvent(long id)
        {
            var userInEvent = await _context.UserInEvents.FindAsync(id);

            if (userInEvent == null)
            {
                return NotFound();
            }

            return userInEvent;
        }

        // PUT: api/UserInEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInEvent(long id, UserInEvent userInEvent)
        {
            if (id != userInEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInEventExists(id))
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

        // POST: api/UserInEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInEvent>> PostUserInEvent(UserInEvent userInEvent)
        {
            _context.UserInEvents.Add(userInEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInEvent", new { id = userInEvent.Id }, userInEvent);
        }

        // DELETE: api/UserInEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInEvent(long id)
        {
            var userInEvent = await _context.UserInEvents.FindAsync(id);
            if (userInEvent == null)
            {
                return NotFound();
            }

            _context.UserInEvents.Remove(userInEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInEventExists(long id)
        {
            return _context.UserInEvents.Any(e => e.Id == id);
        }
    }
}
