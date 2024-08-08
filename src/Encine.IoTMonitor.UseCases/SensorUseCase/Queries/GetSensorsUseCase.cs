using Encine.IoTMonitor.Domain.Entities;
using Encine.IoTMonitor.UseCases.Dtos;
using Encine.IoTMonitor.UseCases.Ports;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encine.IoTMonitor.UseCases.SensorUseCase.Queries
{
    public sealed class GetSensorsUseCase : IRequestHandler<GetSensorDto, IEnumerable<GetSensorDtoResponse>>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetSensorsUseCase(ILogger logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetSensorDtoResponse>> Handle(GetSensorDto request, CancellationToken cancellationToken)
        {
            _logger.Information("Getting sensors");

            var sensors = await _unitOfWork.Repository<Sensor>().GetAllAsync();
            
            var result = new List<GetSensorDtoResponse>();
            
            foreach (var sensor in sensors) {
                result.Add(new GetSensorDtoResponse(
                    sensor.Id,
                    sensor.Name,
                    sensor.Type.ToString(),
                    sensor.Active));
            }

            return result;
        }
    }
}
