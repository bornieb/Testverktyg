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
    public class AlternativesController : ControllerBase
    {
        private readonly TestverktygAPIContext _context;

        public AlternativesController(TestverktygAPIContext context)
        {
            _context = context;
        }

        // GET: api/Alternatives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alternative>>> GetAlternative()
        {
            return await _context.Alternative.ToListAsync();
        }

        // GET: api/Alternatives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alternative>> GetAlternative(int id)
        {
            var alternative = await _context.Alternative.FindAsync(id);

            if (alternative == null)
            {
                return NotFound();
            }

            return alternative;
        }

        // PUT: api/Alternatives/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlternative(int id, Alternative alternative)
        {
            if (id != alternative.AlternativeId)
            {
                return BadRequest();
            }

            _context.Entry(alternative).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlternativeExists(id))
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

        // POST: api/Alternatives
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Alternative>> PostAlternative(Alternative alternative)
        {
            _context.Alternative.Add(alternative);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlternative", new { id = alternative.AlternativeId }, alternative);
        }

        // DELETE: api/Alternatives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Alternative>> DeleteAlternative(int id)
        {
            var alternative = await _context.Alternative.FindAsync(id);
            if (alternative == null)
            {
                return NotFound();
            }

            _context.Alternative.Remove(alternative);
            await _context.SaveChangesAsync();

            return alternative;
        }

        private bool AlternativeExists(int id)
        {
            return _context.Alternative.Any(e => e.AlternativeId == id);
        }
    }
}
