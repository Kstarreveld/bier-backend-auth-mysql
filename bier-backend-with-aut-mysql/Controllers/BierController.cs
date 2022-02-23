#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bier_backend_with_aut_mysql.Models;
using Microsoft.AspNetCore.Authorization;

namespace bier_backend_with_aut_mysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BierController : ControllerBase
    {
        private readonly bierContext _context;

        public BierController(bierContext context)
        {
            _context = context;
        }

        // GET: api/Bier
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Bier>>> GetBiers()
        {
            return await _context.Biers.ToListAsync();
        }

        // GET: api/Bier/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bier>> GetBier(int id)
        {
            var bier = await _context.Biers.FindAsync(id);

            if (bier == null)
            {
                return NotFound();
            }

            return bier;
        }

        // PUT: api/Bier/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBier(int id, Bier bier)
        {
            if (id != bier.Id)
            {
                return BadRequest();
            }

            _context.Entry(bier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BierExists(id))
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

        // POST: api/Bier
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bier>> PostBier(Bier bier)
        {
            _context.Biers.Add(bier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBier", new { id = bier.Id }, bier);
        }

        // DELETE: api/Bier/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBier(int id)
        {
            var bier = await _context.Biers.FindAsync(id);
            if (bier == null)
            {
                return NotFound();
            }

            _context.Biers.Remove(bier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BierExists(int id)
        {
            return _context.Biers.Any(e => e.Id == id);
        }
    }
}
