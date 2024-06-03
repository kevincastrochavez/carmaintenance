using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarMaintenance.Data;
using CarMaintenance.Models.Domain;

namespace CarMaintenance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceRecordsController : ControllerBase
    {
        private readonly CarsDbContext _context;

        public MaintenanceRecordsController(CarsDbContext context)
        {
            _context = context;
        }

        // GET: api/MaintenanceRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceRecord>>> GetMaintenanceRecords()
        {
            return await _context.MaintenanceRecords.ToListAsync();
        }

        // GET: api/MaintenanceRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceRecord>> GetMaintenanceRecord(Guid id)
        {
            var maintenanceRecord = await _context.MaintenanceRecords.FindAsync(id);

            if (maintenanceRecord == null)
            {
                return NotFound();
            }

            return maintenanceRecord;
        }
    }
}
