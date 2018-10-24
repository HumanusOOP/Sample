using System.Threading.Tasks;
using EFDomain.Data;

namespace EFDomain.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetPerson(int id);
    }
}