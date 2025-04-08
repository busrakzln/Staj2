using Staj2Proje.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staj2Proje.Services
{
    public interface IOutageService
    {
        Task<List<OutageService>> GetAllOutages();
        Task<OutageService> GetOutageById(int id);
        Task CreateOutage(OutageService outage);
        Task UpdateOutage(OutageService outage);
        Task DeleteOutage(int id);
        Task UpdateOutage(Outage outage);
        Task CreateOutage(Outage outage);
    }
}
