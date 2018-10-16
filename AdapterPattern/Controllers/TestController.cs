using System;
using System.Net;
using System.Threading.Tasks;
using AdapterPattern.Domain.Better;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdapterPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IBetterSocketAdapter<IIdahoBetterAdaptee> _idahoAdapter;
        private readonly IBetterSocketAdapter<ISwedishBetterAdaptee> _swedishAdapter;

        public TestController(ILogger<TestController> logger, IBetterSocketAdapter<IIdahoBetterAdaptee> idahoAdapter, IBetterSocketAdapter<ISwedishBetterAdaptee> swedishAdapter)
        {
            _logger = logger;
            _idahoAdapter = idahoAdapter;
            _swedishAdapter = swedishAdapter;
        }

        [HttpGet]
        [Route("{geo}")]
        public async Task<IActionResult> Get(string geo)
        {
            try
            {
                var values = string.Empty;
                if (geo.Equals("sv", StringComparison.OrdinalIgnoreCase))
                    values = $"Current: {_swedishAdapter.GetCurrent()} A, Voltage: {_swedishAdapter.GetVoltage()} V, Frequency: {_swedishAdapter.GetFrequency()} Hz";
                else if (geo.Equals("id", StringComparison.OrdinalIgnoreCase))
                    values = $"Current: {_idahoAdapter.GetCurrent()} A, Voltage: {_idahoAdapter.GetVoltage()} V, Frequency: {_idahoAdapter.GetFrequency()} Hz";;

                var response = $"Yay! Success.{Environment.NewLine}Here are the values for the different sockets:{Environment.NewLine}";
                response += $"Values - {values}{Environment.NewLine}";
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
