using Encine.IoTMonitor.UseCases.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Encine.IoTMonitor.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SensorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSensors(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetSensorDto(), cancellationToken));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SensorDtoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSensor([FromBody] SensorDto request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensorById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetSensorByIdDto(id), cancellationToken));
        }
    }
}
