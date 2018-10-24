using System;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using EFDomain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployee(id);

                if (employee == null)
                    return StatusCode((int) HttpStatusCode.NotFound);

                return Ok(employee);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
                return BadRequest($"PersonType mismatch");
            }
        }
    }
}