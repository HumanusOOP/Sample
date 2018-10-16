using System;
using System.Net;
using System.Threading.Tasks;
using AdapterPattern.Domain.Simple;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdapterPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ISocketAdapter _socketAdapter;

        public SimpleController(ILogger<TestController> logger, ISocketAdapter socketAdapter)
        {
            _logger = logger;
            _socketAdapter = socketAdapter;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var socketValues = $"Current: {_socketAdapter.GetCurrent()} A, Voltage: {_socketAdapter.GetVoltage()} V, Frequency: {_socketAdapter.GetFrequency()} Hz";
                var response = $"Yay! Success.{Environment.NewLine}Here are the values for the the Idaho sockets:{Environment.NewLine}";
                response += $"{socketValues}{Environment.NewLine}";
                return await Task.Run(() => Ok(response));
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unknown error in {nameof(TestController)}, details: {exception.Message}");
                return await Task.Run(() => StatusCode((int)HttpStatusCode.InternalServerError, "An unknown error occurred"));
            }
        }
    }
}