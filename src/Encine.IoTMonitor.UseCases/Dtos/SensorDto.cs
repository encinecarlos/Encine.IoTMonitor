using Encine.IoTMonitor.Domain.Enums;
using MediatR;

namespace Encine.IoTMonitor.UseCases.Dtos
{
    public record SensorDto(string name, SensorType type, bool active) : IRequest<SensorDtoResponse>;
}
