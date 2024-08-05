using Encine.IoTMonitor.Domain.Entities;
using Encine.IoTMonitor.Domain.Interfaces;
using Encine.IoTMonitor.UseCases.Dtos;
using Encine.IoTMonitor.UseCases.Ports;
using MediatR;
using Serilog;

namespace Encine.IoTMonitor.UseCases.SensorUseCase
{
    public sealed class SensorHandlerUseCase : IRequestHandler<SensorDto, SensorDtoResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public SensorHandlerUseCase(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

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
