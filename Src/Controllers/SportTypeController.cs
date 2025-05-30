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
            return await _context.SportTypes.ToListAsync();
        }

        // GET: api/SportType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SportType>> GetSportType(long id)
        {
            var sportType = await _context.SportTypes.FindAsync(id);

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
            if (id != sportType.ID)
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
            _context.SportTypes.Add(sportType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSportType), new { id = sportType.ID }, sportType);
        }

        // DELETE: api/SportType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportType(long id)
        {
            var sportType = await _context.SportTypes.FindAsync(id);
            if (sportType == null)
            {
                return NotFound();
            }

            _context.SportTypes.Remove(sportType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SportTypeExists(long id)
        {
            return _context.SportTypes.Any(e => e.ID == id);
        }
    }
}
