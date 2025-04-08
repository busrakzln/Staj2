using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Staj2Proje.Data; // DbContext'in bulunduğu namespace
using Staj2Proje.Models; // Model sınıflarının bulunduğu namespace

namespace Staj2Proje.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;

        // Constructor: ApplicationDbContext'i alır
        public InvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Tüm faturaları getir
        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }

        // ID'ye göre fatura getir
        public async Task<Invoice> GetInvoiceById(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        // Yeni fatura oluştur
        public async Task CreateInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        // Mevcut faturayı güncelle
        public async Task UpdateInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Faturayı sil
        public async Task DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
