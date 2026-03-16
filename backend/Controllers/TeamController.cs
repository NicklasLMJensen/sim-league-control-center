using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimleagueControlCenter.Dtos;
using SimLeagueControlCenter.Models;
using SimLeagueControlCenter.Data;
using System.IO.Compression;
using SimLeagueControlCenter.Dtos;


namespace SimleagueControlCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            var teams = await _context.Teams
                .Select(t => new TeamDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    PrimaryColor = t.PrimaryColor
                })
                .ToListAsync();

                
                return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> GetTeam(int id)
        {
            var team = await _context.Teams
                .Where(t => t.Id == id)
                .Select(t => new TeamDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    PrimaryColor = t.PrimaryColor
                })
                .FirstOrDefaultAsync();

                if (team == null) return NotFound();
                return Ok(team);
        }


        [HttpPost]
        public async Task<ActionResult<TeamDto>> PostTeam(CreateTeamDto dto)
        {
            var team = new Team
            {
                Name = dto.Name,
                Description = dto.Description,
                PrimaryColor = dto.PrimaryColor,
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            var response = new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                PrimaryColor = team.PrimaryColor
            };

            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, response);
        }
    }
}