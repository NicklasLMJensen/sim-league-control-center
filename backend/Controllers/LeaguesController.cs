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
            var leagues = await _context.Leagues.ToListAsync();
            return Ok(leagues);
        }
    }
}