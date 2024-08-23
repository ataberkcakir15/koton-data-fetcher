using Business.Abstract;
using Core.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Plants.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantsController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet("information")]
        public async Task<IActionResult> GetAsync()
        {
            var serviceResult = await _plantService.GetPlantInformationsAsync();
            return StatusCode((int)serviceResult.HttpStatusCode, serviceResult);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePlantRequestModel model)
        {
            var serviceResult = await _plantService.CreatePlantAsync(model);
            return StatusCode((int)serviceResult.HttpStatusCode,serviceResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdatePlantRequestModel model)
        {
            var serviceResult = await _plantService.UpdatePlantAsync(id, model);
            return StatusCode((int)serviceResult.HttpStatusCode, serviceResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var serviceResult = await _plantService.DeletePlantAsync(id);
            return StatusCode((int)serviceResult.HttpStatusCode, serviceResult);
        }
    }
}

// https://localhost:7189/Flowers/information
