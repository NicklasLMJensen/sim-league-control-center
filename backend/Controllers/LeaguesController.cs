using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimLeagueControlCenter.Data;
using SimLeagueControlCenter.Models;

namespace SimleagueControlCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaguesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaguesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<League>>> GetLeagues()
        {
            return await _context.Leagues.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<League>> GetLeague(int id)
        {
            var league = await _context.Leagues.FindAsync(id);
            if (league == null) return NotFound();
            return league;
        }


        [HttpPost]
        public async Task<ActionResult<League>> PostLeague(League league)
        {
            _context.Leagues.Add(league);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLeague), new { id = league.Id }, league);
        }
    }
}