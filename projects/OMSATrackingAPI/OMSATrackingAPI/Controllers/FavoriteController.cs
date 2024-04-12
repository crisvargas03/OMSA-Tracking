using Microsoft.AspNetCore.Mvc;
using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Services;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _service;

        public FavoriteController(IFavoriteService service)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetById(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FavoriteBusStopDto addFavoriteRequest)
        {
            var response = await _service.Add(addFavoriteRequest);

            if (response.IsSuccess)
            {
                return StatusCode((int)response.StatusCode, response);
            }

            return BadRequest(response);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] FavoriteBusStopDto favoriteDto)
        //{
        //    var response = await _service.Update(id, favoriteDto);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }

        //    return BadRequest(response);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var response = await _service.Delete(id);
            return StatusCode((int)response.StatusCode, response);
        }

    }
}
