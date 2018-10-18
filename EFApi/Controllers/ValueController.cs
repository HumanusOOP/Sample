using System;
using System.Net;
using System.Threading.Tasks;
using EFApi.Models;
using EFDomain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly IValueService _valueService;

        public ValueController(IValueService valueService)
        {
            _valueService = valueService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int? id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentException($"Parameter {nameof(id)} cannot be null", nameof(id));

                var value = await _valueService.GetValueAsync(id.Value);

                if (value == null)
                    return StatusCode((int) HttpStatusCode.NotFound);

                var valueModel = new ValueModel(value);
                return Ok(valueModel);
            }
            catch (ArgumentException argumentException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostAsync([FromBody] ValueModel valueModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(valueModel.Content))
                    return BadRequest($"{nameof(valueModel.Content)} cannot be null or empty.");

                await _valueService.AddValueAsync(valueModel.Content);
                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}
