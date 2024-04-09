using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Services;
using System.Threading.Tasks;

namespace OMSATrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStopController : ControllerBase
    {
        private readonly IBusStopService _service;
        public BusStopController(IBusStopService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] string query, [FromQuery] int busLimit = 5)
        {
            var response = await _service.GetAll(query, busLimit);
            if (response.IsSuccess)
            {
                return Ok(new
                {
                    statusCode = 200,
                    errorMessages = new string[] { },
                    payload = response.Payload
                });
            }
            return BadRequest(new
            {
                statusCode = 400,
                isSuccess = false,
                errorMessages = response.ErrorMessages,
                payload = new object[] { }
            });
        }

    }
}
