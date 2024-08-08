using Encine.IoTMonitor.Domain.Entities;
using Encine.IoTMonitor.UseCases.Dtos;
using Encine.IoTMonitor.UseCases.Ports;
using MediatR;
using Serilog;

namespace Encine.IoTMonitor.UseCases.SensorUseCase.Commands
{
    public sealed class SensorHandlerUseCase(IUnitOfWork unitOfWork, ILogger logger) : IRequestHandler<SensorDto, SensorDtoResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger _logger = logger;

        public async Task<SensorDtoResponse> Handle(SensorDto request, CancellationToken cancellationToken)
        {
            _logger.Information("Creating sensor {@Sensor}", request);

            var sensor = Sensor.Create(request.name, request.type, request.active);

            var newSensor = _unitOfWork.Repository<Sensor>().CreateAsync(sensor);

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new SensorDtoResponse(sensor.Id));
        }
    }
}
