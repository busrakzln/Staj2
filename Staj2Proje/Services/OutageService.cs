using Microsoft.EntityFrameworkCore;
using Staj2Proje.Data; // DbContext'in bulunduğu namespace
using Staj2Proje.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staj2Proje.Services
{
    public class OutageService : IOutageService
    {
        private readonly ApplicationDbContext _context;

        public OutageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Outage>> GetAllOutages()
        {
            return await _context.Outages.ToListAsync();
        }

        public async Task<Outage> GetOutageById(int id)
        {
            return await _context.Outages.FindAsync(id);
        }

        public async Task CreateOutage(Outage outage)
        {
            await _context.Outages.AddAsync(outage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOutage(Outage outage)
        {
            _context.Outages.Update(outage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOutage(int id)
        {
            var outage = await _context.Outages.FindAsync(id);
            if (outage != null)
            {
                _context.Outages.Remove(outage);
                await _context.SaveChangesAsync();
            }
        }

        Task<List<OutageService>> IOutageService.GetAllOutages()
        {
            throw new NotImplementedException();
        }

        Task<OutageService> IOutageService.GetOutageById(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateOutage(OutageService outage)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOutage(OutageService outage)
        {
            throw new NotImplementedException();
        }
    }
}
