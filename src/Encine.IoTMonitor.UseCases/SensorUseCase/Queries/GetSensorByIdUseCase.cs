using Encine.IoTMonitor.Domain.Entities;
using Encine.IoTMonitor.UseCases.Dtos;
using Encine.IoTMonitor.UseCases.Ports;
using MediatR;
using Serilog;

namespace Encine.IoTMonitor.UseCases.SensorUseCase.Queries
{
    public sealed class GetSensorByIdUseCase : IRequestHandler<GetSensorByIdDto, GetSensorDtoResponse?>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetSensorByIdUseCase(ILogger logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetSensorDtoResponse?> Handle(GetSensorByIdDto request, CancellationToken cancellationToken)
        {
            _logger.Information($"Getting sensor by id: {request.sensorId}");

            var sensor = await _unitOfWork.Repository<Sensor>().GetById(request.sensorId);

            var result = sensor != null ? new GetSensorDtoResponse(
                sensor.Id,
                sensor.Name,
                sensor.Type.ToString(),
                sensor.Active) : null;

            return result;
        }
    }
}
