using System.Threading.Tasks;
using EFDomain.Data;

namespace EFDomain.Repositories.Interfaces
{
    public interface IValueRepository
    {
        Task<Value> GetValueAsync(int id);
        Task AddValueAsync(Value value);
    }
}