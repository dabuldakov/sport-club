using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportClubApi.DataBase;
using SportClubApi.Mapper;
using SportClubApi.Models;

namespace SportClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletController(ApplicationContext context, AthletMapper mapper) : ControllerBase
    {
        private readonly ApplicationContext _context = context;
        private readonly AthletMapper _mapper = mapper;

        // GET: api/Athlet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AthletDto>>> GetAthlets()
        {
            var athlets = await _context.Athlets.ToListAsync();
            var result = athlets.Select(_mapper.ToDto).ToList();
            return Ok(result);
        }

        // GET: api/Athlet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AthletDto>> GetAthlet(long id)
        {
            var athlet = await _context.Athlets.FindAsync(id);

            if (athlet == null)
            {
                return NotFound();
            }

            return _mapper.ToDto(athlet);
        }

        // PUT: api/Athlet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAthlet(long id, AthletDto athlet)
        {
            if (id != athlet.Id)
            {
                return BadRequest();
            }

            _context.Entry(_mapper.ToDomain(athlet)).State = EntityState.Modified;

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
        public async Task<ActionResult<AthletDto>> PostAthlet(AthletDto dto)
        {
            var athlet = _mapper.ToDomain(dto);
            _context.Athlets.Add(athlet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAthlet), new { id = athlet.Id }, _mapper.ToDto(athlet));
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
