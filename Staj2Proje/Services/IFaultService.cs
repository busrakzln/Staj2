using Staj2Proje.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staj2Proje.Services
{
    public interface IFaultService
    {
        Task<List<Fault>> GetAllFaults();
        Task<Fault> GetFaultById(int id);
        Task CreateFault(Fault fault);
        Task UpdateFault(Fault fault);
        Task DeleteFault(int id);
    }
}
