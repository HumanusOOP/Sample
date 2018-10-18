using System.Threading.Tasks;
using EFDomain.Data;
using EFDomain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFDomain.Repositories
{
    public class ValueRepository : IValueRepository
    {
        private readonly SampleContext _sampleContext;

        public ValueRepository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public async Task<Value> GetValueAsync(int id)
        {
            var value = await _sampleContext.Entities.Include(e => e.Inquiry).
                FirstOrDefaultAsync(table => table.Id.Equals(id));
            return value;
        }

        public async Task AddValueAsync(Value value)
        {
            await _sampleContext.Entities.AddAsync(value);
            await _sampleContext.SaveChangesAsync();
        }
    }
}
