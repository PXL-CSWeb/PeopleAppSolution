using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleApp.Api.Data;
using PeopleApp.Api.Services;
using PeopleApp.ClassLib.Models;

namespace PeopleApp.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;

        public LocationController(ILocationService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetLocations()
        {
            try
            {
                var locations = await _service.ListLocationsAsync();

                return Ok(locations);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(long id)
        {
            try
            {
                var location = await _service.GetLocationAsync(id);

                if (location is null)
                    return NotFound();

                return Ok(location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Location>> AddLocation(Location model)
        {
            try
            {
                model = await _service.AddLocationAsync(model);
                return Ok(model );
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(Location model)
        {
            try
            {
                await _service.UpdateLocationAsync(model);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(long id)
        {
            try
            {
                await _service.DeleteLocationAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
