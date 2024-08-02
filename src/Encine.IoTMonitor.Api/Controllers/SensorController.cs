using Microsoft.AspNetCore.Mvc;

namespace Encine.IoTMonitor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSensors()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSensor()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensorById(Guid id)
        {
            return Ok();
        }
    }
}
