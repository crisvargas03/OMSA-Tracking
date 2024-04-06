using Microsoft.AspNetCore.Mvc;
using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;

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

        [HttpPost]
        public async Task Add([FromBody] DAL.Models.Route addRouteRequest)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return;
            }

            await _service.Add(addRouteRequest);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var response = await _service.Delete(id);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
