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
        public async Task<IActionResult> GetCar(Guid id)
        {
            var carModel = await _carRepository.GetByIdAsync(id);

            if (carModel == null)
            {
                return NotFound();
            }

            var carDto = _mapper.Map<CarDto>(carModel);

            return Ok(carDto);
        }
    }
}
