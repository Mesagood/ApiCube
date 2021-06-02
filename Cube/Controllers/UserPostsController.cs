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
    public class UserPostsController : ControllerBase
    {
        private readonly ItCubeContext _context;

        public UserPostsController(ItCubeContext context)
        {
            _context = context;
        }

        // GET: api/UserPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPost>>> GetUserPosts()
        {
            return await _context.UserPosts.ToListAsync();
        }

        // GET: api/UserPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPost>> GetUserPost(long id)
        {
            var userPost = await _context.UserPosts.FindAsync(id);

            if (userPost == null)
            {
                return NotFound();
            }

            return userPost;
        }

        // PUT: api/UserPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPost(long id, UserPost userPost)
        {
            if (id != userPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(userPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPostExists(id))
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

        // POST: api/UserPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPost>> PostUserPost(UserPost userPost)
        {
            _context.UserPosts.Add(userPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPost", new { id = userPost.Id }, userPost);
        }

        // DELETE: api/UserPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPost(long id)
        {
            var userPost = await _context.UserPosts.FindAsync(id);
            if (userPost == null)
            {
                return NotFound();
            }

            _context.UserPosts.Remove(userPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPostExists(long id)
        {
            return _context.UserPosts.Any(e => e.Id == id);
        }
    }
}
