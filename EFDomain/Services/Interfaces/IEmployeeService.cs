using System.Threading.Tasks;
using EFDomain.Models;

namespace EFDomain.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(int id);
    }
}