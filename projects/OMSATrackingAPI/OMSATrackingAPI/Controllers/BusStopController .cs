using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMSATrackingAPI.BLL.Interfaces;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
