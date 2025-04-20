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
    public class ClubController(ApplicationContext context, ClubMapper mapper) : ControllerBase
    {
        private readonly ApplicationContext _context = context;
        private readonly ClubMapper _mapper = mapper;

        // GET: api/Club
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClubDto>>> GetClubs()
        {
            var clubs = await _context.Clubs.ToListAsync();
            var result = clubs.Select(_mapper.ToDto).ToList();
            return Ok(result);
        }

        // GET: api/Club/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClubDto>> GetClub(long id)
        {
            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return _mapper.ToDto(club);
        }

        // PUT: api/Club/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClub(long id, ClubDto club)
        {
            if (id != club.Id)
            {
                return BadRequest();
            }

            _context.Entry(_mapper.ToDomain(club)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
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

        // POST: api/Club
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Club>> PostClub(ClubDto dto)
        {
            var club = _mapper.ToDomain(dto);
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClub), new { id = club.ID }, _mapper.ToDto(club));
        }

        // DELETE: api/Club/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(long id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClubExists(long id)
        {
            return _context.Clubs.Any(e => e.ID == id);
        }
    }
}
