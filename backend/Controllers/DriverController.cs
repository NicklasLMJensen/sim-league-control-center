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
    public class DriverController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DriverController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDto>>> GetDrivers()
        {
            var Drivers = await _context.Drivers
                .Select(d => new DriverDto
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Nationality = d.Nationality,
                    IracingId = d.IracingId
                })
                .ToListAsync();
            return Ok(Drivers);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DriverDto>> GetDriver(int id)
        {
            var driver = await _context.Drivers
                .Where(d => d.Id == id)
                .Select(d => new DriverDto
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Nationality = d.Nationality,
                    IracingId = d.IracingId
                })
                .FirstOrDefaultAsync();

            if (driver == null) return NotFound();
            return Ok(driver);
        }


        [HttpPost]
        public async Task<ActionResult<DriverDto>> PostDriver(CreateDriverDto Dto)
        {
            var driver = new Driver
            {
                FirstName = Dto.FirstName,
                LastName = Dto.LastName,
                Nationality = Dto.Nationality,
                IracingId = Dto.IracingId
            };

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            var response = new DriverDto
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Nationality = driver.Nationality,
                IracingId = driver.IracingId
            };

            return CreatedAtAction(nameof(GetDriver), new { id = driver.Id}, response);
        }
    }
}