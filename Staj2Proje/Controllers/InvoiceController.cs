using Microsoft.AspNetCore.Mvc;
using Staj2Proje.Models; // Model sınıflarının bulunduğu namespace
using Staj2Proje.Services; // Service sınıflarının bulunduğu namespace
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staj2Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        // Constructor: InvoiceService'i alır
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // Tüm faturaları getir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        // ID'ye göre fatura getir
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _invoiceService.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        // Yeni fatura oluştur
        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            await _invoiceService.CreateInvoice(invoice);
            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
        }

        // Faturayı güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }
            await _invoiceService.UpdateInvoice(invoice);
            return NoContent();
        }

        // Faturayı sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            await _invoiceService.DeleteInvoice(id);
            return NoContent();
        }
    }
}
