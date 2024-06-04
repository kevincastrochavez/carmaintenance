using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarMaintenance.Data;
using CarMaintenance.Models.Domain;
using CarMaintenance.Repositories;
using AutoMapper;

namespace CarMaintenance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarsController(ICarRepository carRepository, IMapper mapper)
        {
            this._carRepository = carRepository;
            this._mapper = mapper;
        }

        // GET: api/Cars
        [HttpGet(Name = "GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            var carsModel = await _carRepository.GetAllAsync();

            var carsDto = _mapper.Map<List<CarDto>>(carsModel);

            return Ok(carsDto);
        }

        // GET: api/Cars/5
        [HttpGet("{id}", Name = "GetCar")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var carModel = await _carRepository.GetByIdAsync(id);

            if (carModel == null)
            {
                return NotFound();
            }

            var carDto = _mapper.Map<CarDto>(carModel);

            return Ok(carDto);
        }

        // POST: api/Cars
        [HttpPost(Name = "CreateCar")]
        public async Task<IActionResult> Create([FromBody] AddCarDto addCarDto)
        {
            // Map DTO to Domain Model
            var carModel = _mapper.Map<Car>(addCarDto);

            // Add to db
            carModel = await _carRepository.CreateAsync(carModel);

            // Map Domain Model to DTO
            var carDto = _mapper.Map<CarDto>(carModel);

            return CreatedAtAction(nameof(GetById), new { id = carModel.CarId }, carModel);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}", Name = "UpdateCar")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCarDto updateCarDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map DTO to Domain Model
            var carModel = _mapper.Map<Car>(updateCarDto);

            // Check if car exists
            carModel = await _carRepository.UpdateAsync(id, carModel);

            if (carModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            var carDto = _mapper.Map<CarDto>(carModel);

            return Ok(carDto);
        }
    }
}
