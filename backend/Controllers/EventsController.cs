using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimleagueControlCenter.Dtos;
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
    }
}