using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimleagueControlCenter.Dtos;
using SimleagueControlCenter.Models;
using SimLeagueControlCenter.Data;
using SimLeagueControlCenter.Dtos;
using SimLeagueControlCenter.Models;


namespace SimleagueControlCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var events = await _context.Events
            .Select(e => new EventDto
            {
                Id = e.Id,
                Name = e.Name,
                Date = e.Date,
                TrackName = e.TrackName,
                SeasonId = e.SeasonId,
                SeasonName = e.Season.Name
            })
            .ToListAsync();


            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var ev = await _context.Events
            .Where(e => e.Id == id)
            .Select(e => new EventDto
            {
                Id = e.Id,
                Name = e.Name,
                Date = e.Date,
                TrackName= e.TrackName,
                SeasonId = e.SeasonId,
                SeasonName = e.Season.Name
            })
            .FirstOrDefaultAsync();

            if (ev == null) return NotFound();
            return Ok(ev);
        }


        [HttpPost]
        public async Task<ActionResult<EventDto>> PostEvent(CreateEventDto dto)
        {
            var seasonExists = await _context.Seasons.AnyAsync(s => s.Id == dto.SeasonId);
            if (!seasonExists) return NotFound($"Season withID {dto.SeasonId} not found.");

            var ev = new Event
            {
                Name = dto.Name,
                Date = dto.Date,
                TrackName = dto.TrackName,
                SeasonId = dto.SeasonId
            };
            
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();

            var response = new EventDto
            {
                Id = ev.Id,
                Name = ev.Name,
                Date = ev.Date,
                TrackName = ev.TrackName,
                SeasonId = ev.SeasonId,
                SeasonName = await _context.Seasons
                    .Where(s => s.Id == ev.SeasonId)
                    .Select(s => s.Name)
                    .FirstAsync()
            };

            return CreatedAtAction(nameof(GetEvent), new { id = ev.Id }, response);
        }
    }
}