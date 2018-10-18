using System;
using System.Threading.Tasks;
using EFDomain.Data;
using EFDomain.Repositories.Interfaces;
using EFDomain.Services.Interfaces;

namespace EFDomain.Services
{
    public class ValueService : IValueService
    {
        private readonly IValueRepository _valueRepository;

        public ValueService(IValueRepository valueRepository)
        {
            _valueRepository = valueRepository;
        }

        public async Task<string> GetValueAsync(int id)
        {
            var value = await _valueRepository.GetValueAsync(id);
            return value?.Content+" "+ value?.Inquiry?.InquiryString;
        }

        public async Task AddValueAsync(string content)
        {
            var value = new Value { Content = content, Active = true };
            await _valueRepository.AddValueAsync(value);
        }
    }
}
