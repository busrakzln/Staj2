using Microsoft.AspNetCore.Mvc;
using Staj2Proje.Models; // Model sınıflarının bulunduğu namespace
using Staj2Proje.Services; // Service sınıflarının bulunduğu namespace
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staj2Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutageController : ControllerBase
    {
        private readonly IOutageService _outageService;

        public OutageController(IOutageService outageService)
        {
            _outageService = outageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Outage>>> GetOutages()
        {
            var outages = await _outageService.GetAllOutages();
            return Ok(outages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Outage>> GetOutage(int id)
        {
            var outage = await _outageService.GetOutageById(id);
            if (outage == null)
            {
                return NotFound();
            }
            return Ok(outage);
        }

        [HttpPost]
        public async Task<ActionResult<Outage>> CreateOutage(Outage outage)
        {
            await _outageService.CreateOutage(outage);
            return CreatedAtAction(nameof(GetOutage), new { id = outage.Id }, outage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOutage(int id, Outage outage)
        {
            if (id != outage.Id)
            {
                return BadRequest();
            }
            await _outageService.UpdateOutage(outage);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOutage(int id)
        {
            await _outageService.DeleteOutage(id);
            return NoContent();
        }
    }
}
