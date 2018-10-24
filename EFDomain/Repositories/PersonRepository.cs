using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFDomain.Data;
using EFDomain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFDomain.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SampleContext _sampleContext;

        public PersonRepository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await _sampleContext.Persons.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return person;
        }
    }
}
