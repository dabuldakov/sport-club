using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportClubApi.Models;

namespace SportClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportTypeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SportTypeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/SportType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportType>>> GetTypes()
        {
            return await _context.Types.ToListAsync();
        }

        // GET: api/SportType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SportType>> GetSportType(long id)
        {
            var sportType = await _context.Types.FindAsync(id);

            if (sportType == null)
            {
                return NotFound();
            }

            return sportType;
        }

        // PUT: api/SportType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportType(long id, SportType sportType)
        {
            if (id != sportType.Id)
            {
                return BadRequest();
            }

            _context.Entry(sportType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportTypeExists(id))
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

        // POST: api/SportType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SportType>> PostSportType(SportType sportType)
        {
            _context.Types.Add(sportType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSportType", new { id = sportType.Id }, sportType);
        }

        // DELETE: api/SportType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportType(long id)
        {
            var sportType = await _context.Types.FindAsync(id);
            if (sportType == null)
            {
                return NotFound();
            }

            _context.Types.Remove(sportType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SportTypeExists(long id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}
