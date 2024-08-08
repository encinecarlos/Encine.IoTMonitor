using MediatR;

namespace Encine.IoTMonitor.UseCases.Dtos
{
    public record GetSensorByIdDto(Guid sensorId) : IRequest<GetSensorDtoResponse?>;
}
