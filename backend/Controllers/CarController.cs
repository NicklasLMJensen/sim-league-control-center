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
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCarDto()
        {
            var Cars = await _context.Cars
                .Select(c => new CarDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Class = c.Class,
                    CarNumber = c.CarNumber
                })
                .ToListAsync();

            return Ok(Cars);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var car = await _context.Cars
                .Where(c => c.Id == id)
                .Select(c => new CarDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Class = c.Class,
                    CarNumber = c.CarNumber
                })
                .FirstOrDefaultAsync();

            if (car == null) return NotFound();
            return Ok(car);
        }


        [HttpPost]
        public async Task<ActionResult<CarDto>> PostCar(CreateCarDto Dto)
        {
            var car = new Car
            {
                Make = Dto.Make,
                Model = Dto.Model,
                Class = Dto.Class,
                CarNumber = Dto.CarNumber
            };

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            var response = new CarDto
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Class = car.Class,
                CarNumber = car.CarNumber
            };

            return CreatedAtAction(nameof(GetCar), new { id = car.Id}, response);
        }
    }
}
