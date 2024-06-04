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
    public class MaintenanceRecordsController : ControllerBase
    {
        private readonly CarsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

        public MaintenanceRecordsController(CarsDbContext context, IMaintenanceRecordRepository maintenanceRecordRepository, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this._maintenanceRecordRepository = maintenanceRecordRepository;
        }

        // GET: api/MaintenanceRecords
        [HttpGet(Name = "GetAllMaintenanceRecords")]
        public async Task<IActionResult> GetAllMaintenanceRecords()
        {
            // Get all MaintenanceRecords
            var maintenanceRecordsModel = await _maintenanceRecordRepository.GetAllAsync();

            // Map MaintenanceRecord to MaintenanceRecordDto
            var maintenanceRecordsDto = _mapper.Map<List<MaintenanceRecordDto>>(maintenanceRecordsModel);

            return Ok(maintenanceRecordsDto);
        }

        // GET: api/MaintenanceRecords/5
        [HttpGet("{id}", Name = "GetMaintenanceRecord")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var maintenanceRecordModel = await _maintenanceRecordRepository.GetByIdAsync(id);

            if (maintenanceRecordModel == null)
            {
                return NotFound();
            }

            var maintenanceRecordDto = _mapper.Map<MaintenanceRecordDto>(maintenanceRecordModel);
            return Ok(maintenanceRecordDto);
        }

        // POST: api/MaintenanceRecords
        [HttpPost(Name = "CreateMaintenanceRecord")]
        public async Task<IActionResult> Create([FromBody] AddMaintenanceRecordDto addMaintenanceRecordDto)
        {
            //    Map DTO to Domain Model
            var maintenanceRecordModel = _mapper.Map<MaintenanceRecord>(addMaintenanceRecordDto);

            // Add to db
            maintenanceRecordModel = await _maintenanceRecordRepository.CreateAsync(maintenanceRecordModel);

            // Map Domain Model to DTO
            var maintenanceRecordDto = _mapper.Map<MaintenanceRecordDto>(maintenanceRecordModel);

            return CreatedAtAction(nameof(GetById), new { id = maintenanceRecordDto.MaintenanceRecordId }, maintenanceRecordDto);
        }

        // PUT: api/MaintenanceRecords/5
        [HttpPut("{id}", Name = "UpdateMaintenanceRecord")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMaintenanceRecordDto updateMaintenanceRecordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map DTO to Domain Model
            var maintenanceRecordModel = _mapper.Map<MaintenanceRecord>(updateMaintenanceRecordDto);

            // Check if maintenanceRecord exists
            maintenanceRecordModel = await _maintenanceRecordRepository.UpdateAsync(id, maintenanceRecordModel);

            if (maintenanceRecordModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            var maintenanceRecordDto = _mapper.Map<MaintenanceRecordDto>(maintenanceRecordModel);

            return Ok(maintenanceRecordDto);
        }
    }
}
