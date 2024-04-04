using Microsoft.AspNetCore.Mvc;
using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Interfaces;

namespace OMSATrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _busService.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _busService.GetById(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response);
        }


        [HttpPost]
        public async Task<IActionResult> InsertBus([FromBody] InsertBusDto busDto)
        {
            var response = await _busService.InsertBus(busDto);
            if (response.IsSuccess)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return BadRequest(response);
        }
    }
}
