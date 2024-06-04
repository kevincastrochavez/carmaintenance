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
        public async Task<ActionResult<IEnumerable<MaintenanceRecord>>> GetMaintenanceRecords()
        {
            // Get all MaintenanceRecords
            var maintenanceRecordsModel = await _maintenanceRecordRepository.GetAllAsync();

            // Map MaintenanceRecord to MaintenanceRecordDto
            var maintenanceRecordsDto = _mapper.Map<List<MaintenanceRecordDto>>(maintenanceRecordsModel);

            return Ok(maintenanceRecordsDto);
        }

        // // GET: api/MaintenanceRecords/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<MaintenanceRecord>> GetMaintenanceRecord(Guid id)
        // {
        //     var maintenanceRecord = await _context.MaintenanceRecords.FindAsync(id);

        //     if (maintenanceRecord == null)
        //     {
        //         return NotFound();
        //     }

        //     return maintenanceRecord;
        // }
    }
}
