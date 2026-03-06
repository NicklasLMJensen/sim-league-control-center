using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimLeagueControlCenter.Data;
using SimLeagueControlCenter.Dtos;
using SimLeagueControlCenter.Models;

namespace SimLeagueControlCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeasonsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Season>>> GetSeasons()
        {
            var seasons = await _context.Seasons.Select(s => new SeasonDto
            {
                Id = s.Id,
                Name = s.Name,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                LeagueId = s.LeagueId,
                LeagueName = s.League.Name
            }).ToListAsync();
            return Ok(seasons);
        }

        [HttpPost]
        public async Task<ActionResult<Season>> PostSeason(CreateSeasonDto Dto)
        {
            var season = new Season
            {
                Name = Dto.Name,
                StartDate = Dto.StartDate,
                EndDate = Dto.EndDate,
                LeagueId = Dto.LeagueId
            };

            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();

            var response = new SeasonDto
            {
                Id = season.Id,
                Name = season.Name,
                StartDate = season.StartDate,
                EndDate = season.EndDate,
                LeagueId = season.LeagueId,
                LeagueName = await _context.Leagues.Where(l =>l.Id == season.LeagueId).Select(l => l.Name).FirstAsync()
            };
            return CreatedAtAction(nameof(GetSeasons), response);
        }

    }
}