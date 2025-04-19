using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportClubApi.DataBase;
using SportClubApi.Models;

namespace SportClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AthletController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Athlet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Athlet>>> GetAthlets()
        {
            return await _context.Athlets.ToListAsync();
        }

        // GET: api/Athlet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Athlet>> GetAthlet(long id)
        {
            var athlet = await _context.Athlets.FindAsync(id);

            if (athlet == null)
            {
                return NotFound();
            }

            return athlet;
        }

        // PUT: api/Athlet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAthlet(long id, Athlet athlet)
        {
            if (id != athlet.Id)
            {
                return BadRequest();
            }

            _context.Entry(athlet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AthletExists(id))
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

        // POST: api/Athlet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Athlet>> PostAthlet(Athlet athlet)
        {
            _context.Athlets.Add(athlet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAthlet", new { id = athlet.Id }, athlet);
        }

        // DELETE: api/Athlet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAthlet(long id)
        {
            var athlet = await _context.Athlets.FindAsync(id);
            if (athlet == null)
            {
                return NotFound();
            }

            _context.Athlets.Remove(athlet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AthletExists(long id)
        {
            return _context.Athlets.Any(e => e.Id == id);
        }
    }
}
