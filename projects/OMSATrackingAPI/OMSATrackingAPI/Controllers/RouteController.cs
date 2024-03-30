using Microsoft.AspNetCore.Mvc;
using OMSATrackingAPI.BLL.Interfaces;

namespace OMSATrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRoutesService _service;
        public RouteController(IRoutesService service)
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

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DAL.Models.Route route)
        {
            if (route == null)
            {
                return BadRequest("Invalid data");
            }

            var response = await _service.Insert(route);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
