using Microsoft.EntityFrameworkCore;
using Staj2Proje.Data; // DbContext'in bulunduğu namespace
using Staj2Proje.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staj2Proje.Services
{
    public class FaultService : IFaultService
    {
        private readonly ApplicationDbContext _context;

        public FaultService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fault>> GetAllFaults()
        {
            return await _context.Faults.ToListAsync();
        }

        public async Task<Fault> GetFaultById(int id)
        {
            return await _context.Faults.FindAsync(id);
        }

        public async Task CreateFault(Fault fault)
        {
            await _context.Faults.AddAsync(fault);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFault(Fault fault)
        {
            _context.Faults.Update(fault);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFault(int id)
        {
            var fault = await _context.Faults.FindAsync(id);
            if (fault != null)
            {
                _context.Faults.Remove(fault);
                await _context.SaveChangesAsync();
            }
        }
    }
}
