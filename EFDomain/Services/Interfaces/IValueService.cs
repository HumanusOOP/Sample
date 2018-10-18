using System.Threading.Tasks;

namespace EFDomain.Services.Interfaces
{
    public interface IValueService
    {
        Task<string> GetValueAsync(int id);
        Task AddValueAsync(string content);
    }
}