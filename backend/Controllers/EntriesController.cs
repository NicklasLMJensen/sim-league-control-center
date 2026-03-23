using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimLeagueControlcenter.Models;
using SimLeagueControlCenter.Data;
using SimLeagueControlCenter.Dtos;
using SimLeagueControlCenter.Models;


namespace SimLeagueControlCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryDto>>> GetEntries()
        {
            var entries = await _context.Entries
                .Select(e => new EntryDto
                {
                    Id = e.Id,
                    SeasonId = e.SeasonId,
                    SeasonName = e.Season.Name, 
                    DriverId = e.DriverId,
                    DriverFirstName = e.Driver.FirstName,
                    DriverLastName = e.Driver.LastName,
                    TeamId = e.TeamId,
                    TeamName = e.Team.Name,
                    CarId = e.CarId,
                    CarMake = e.Car.Make,
                    CarModel = e.Car.Model,
                    RaceNumber = e.RaceNumber

                })
                .ToListAsync();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntryDto>> GetEntry(int id)
        {
            var entry = await _context.Entries
                .Where(e => e.Id == id)
                .Select(e => new EntryDto
                {
                    Id = e.Id,
                    SeasonId = e.SeasonId,
                    SeasonName = e.Season.Name, 
                    DriverId = e.DriverId,
                    DriverFirstName = e.Driver.FirstName,
                    DriverLastName = e.Driver.LastName,
                    TeamId = e.TeamId,
                    TeamName = e.Team.Name,
                    CarId = e.CarId,
                    CarMake = e.Car.Make,
                    CarModel = e.Car.Model,
                    RaceNumber = e.RaceNumber
                })
                .FirstOrDefaultAsync();

            if(entry == null) return NotFound();
            return Ok(entry);
        }

        [HttpPost]
        public async Task<ActionResult<EntryDto>> PostEntry(CreateEntryDto dto)
        {
            var seasonExists = await _context.Seasons.AnyAsync(s => s.Id == dto.SeasonId);
                if (!seasonExists) return NotFound($"Season with ID {dto.SeasonId} not found.");
            
            var driverExists = await _context.Drivers.AnyAsync(d => d.Id == dto.DriverId);
                if (!driverExists) return NotFound($"Driver with ID {dto.DriverId} not found.");

            var teamExists = await _context.Teams.AnyAsync(t => t.Id == dto.TeamId);
                if (!teamExists) return NotFound($"Team with ID {dto.TeamId} not found.");

            var carExists = await _context.Cars.AnyAsync(c => c.Id == dto.CarId);
                if (!carExists) return NotFound($"Car with ID {dto.CarId} not found.");


            var entry = new Entry
            {
                SeasonId = dto.SeasonId,
                DriverId = dto.DriverId,
                TeamId = dto.TeamId,
                CarId = dto.CarId,
                RaceNumber = dto.RaceNumber
            };

            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();

            var response = new EntryDto
            {
                Id = entry.Id,
                SeasonId = entry.SeasonId,
                SeasonName = await _context.Seasons
                    .Where(s => s.Id == entry.SeasonId)
                    .Select(s => s.Name)
                    .FirstAsync(),
                DriverId = entry.DriverId,
                DriverFirstName = await _context.Drivers
                    .Where(d => d.Id == entry.DriverId)
                    .Select(d => d.FirstName)
                    .FirstAsync(),
                DriverLastName = await _context.Drivers
                    .Where(d => d.Id == entry.DriverId)
                    .Select(d => d.LastName)
                    .FirstAsync(),
                TeamId = entry.TeamId,
                TeamName = await _context.Teams
                    .Where(t => t.Id == entry.TeamId)
                    .Select(t => t.Name)
                    .FirstAsync(),
                CarId = entry.CarId,
                CarMake = await _context.Cars
                    .Where(c => c.Id == entry.CarId)
                    .Select(c => c.Make)
                    .FirstAsync(),
                CarModel = await _context.Cars
                    .Where(c => c.Id == entry.CarId)
                    .Select(c => c.Model)
                    .FirstAsync(),
                RaceNumber = entry.RaceNumber
                    
            };

            return CreatedAtAction(nameof(GetEntry), new { id = entry.Id }, response);
        }
    }
}