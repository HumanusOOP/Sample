using System;
using System.Threading.Tasks;
using EFDomain.Data;
using EFDomain.Models;
using EFDomain.Repositories.Interfaces;
using EFDomain.Services.Interfaces;

namespace EFDomain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IPersonRepository _personRepository;

        public EmployeeService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var person = await _personRepository.GetPerson(id);

            if (person == null)
                return null;

            if (person.PersonType != PersonType.Employee)
                throw new InvalidOperationException($"Expected type Employee but was of type '{Enum.GetName(typeof(PersonType), person.PersonType)}'");

            var employee = new Employee
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email
            };

            return employee;
        }
    }
}
