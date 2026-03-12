using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimleagueControlCenter.Dtos;
using SimleagueControlCenter.Models;
using SimLeagueControlCenter.Data;
using SimLeagueControlCenter.Models;

namespace SimleagueController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetSessions()
        {
            var sessions = await _context.Sessions
                .Select(s => new SessionDto
                {
                    Id = s.Id,
                    Type = s.Type,
                    StartTime = s.StartTime,
                    Duration = s.Duration,
                    EventId = s.EventId,
                    EventName = s.Event.Name
                })
                .ToListAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDto>> GetSession(int id)
        {
            var session = await _context.Sessions
                .Where(s => s.Id == id)
                .Select(s => new SessionDto
                {
                    Id= s.Id,
                    Type = s.Type,
                    StartTime = s.StartTime,
                    Duration = s.Duration,
                    EventId = s.EventId,
                    EventName = s.Event.Name
                })
                .FirstOrDefaultAsync();

            if (session == null) return NotFound();
            return Ok(session);
        }

        [HttpPost]
        public async Task<ActionResult<SessionDto>> PostSession(CreateSessionDto Dto)
        {
            var eventExists = await _context.Events.AnyAsync(e => e.Id == Dto.EventId);
            if (!eventExists) return BadRequest($"Event with ID {Dto.EventId} does not exist.");

            var session = new Session
            {
                Type = Dto.Type,
                StartTime = Dto.StartTime,
                Duration = Dto.Duration,
                EventId = Dto.EventId
            };

            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            var response = new SessionDto
            {
                Id = session.Id,
                Type = session.Type,
                StartTime = session.StartTime,
                Duration = session.Duration,
                EventId = session.EventId,
                EventName = await _context.Events
                    .Where(e => e.Id == session.EventId)
                    .Select(e => e.Name)
                    .FirstAsync()
            };

            return CreatedAtAction(nameof(GetSession), new { id = session.Id }, response);
        }
    }
}