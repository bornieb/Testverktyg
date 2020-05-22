using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestverktygAPI.Data;
using TestverktygAPI.Models;

namespace TestverktygAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordController : ControllerBase
    {
        private readonly TestverktygAPIContext _context;

        public KeywordController(TestverktygAPIContext context)
        {
            _context = context;
        }

        // GET: api/Keyword
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Keyword>>> GetKeyword()
        {
            return await _context.Keyword.ToListAsync();
        }

        // GET: api/Keyword/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Keyword>> GetKeyword(int id)
        {
            var keyword = await _context.Keyword.FindAsync(id);

            if (keyword == null)
            {
                return NotFound();
            }

            return keyword;
        }

        // PUT: api/Keyword/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeyword(int id, Keyword keyword)
        {
            if (id != keyword.KeywordId)
            {
                return BadRequest();
            }

            _context.Entry(keyword).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeywordExists(id))
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

        // POST: api/Keyword
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Keyword>> PostKeyword(Keyword keyword)
        {
            _context.Keyword.Add(keyword);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeyword", new { id = keyword.KeywordId }, keyword);
        }

        // DELETE: api/Keyword/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Keyword>> DeleteKeyword(int id)
        {
            var keyword = await _context.Keyword.FindAsync(id);
            if (keyword == null)
            {
                return NotFound();
            }

            _context.Keyword.Remove(keyword);
            await _context.SaveChangesAsync();

            return keyword;
        }

        private bool KeywordExists(int id)
        {
            return _context.Keyword.Any(e => e.KeywordId == id);
        }
    }
}
