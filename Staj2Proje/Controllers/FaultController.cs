using Microsoft.AspNetCore.Mvc;
using Staj2Proje.Models; // Model sınıflarının bulunduğu namespace
using Staj2Proje.Services; // Service sınıflarının bulunduğu namespace
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staj2Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultController : ControllerBase
    {
        private readonly IFaultService _faultService;

        public FaultController(IFaultService faultService)
        {
            _faultService = faultService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fault>>> GetFaults()
        {
            var faults = await _faultService.GetAllFaults();
            return Ok(faults);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fault>> GetFault(int id)
        {
            var fault = await _faultService.GetFaultById(id);
            if (fault == null)
            {
                return NotFound();
            }
            return Ok(fault);
        }

        [HttpPost]
        public async Task<ActionResult<Fault>> CreateFault(Fault fault)
        {
            await _faultService.CreateFault(fault);
            return CreatedAtAction(nameof(GetFault), new { id = fault.Id }, fault);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFault(int id, Fault fault)
        {
            if (id != fault.Id)
            {
                return BadRequest();
            }
            await _faultService.UpdateFault(fault);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFault(int id)
        {
            await _faultService.DeleteFault(id);
            return NoContent();
        }
    }
}
