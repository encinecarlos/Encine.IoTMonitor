using MediatR;

namespace Encine.IoTMonitor.UseCases.Dtos
{
    public record GetSensorDto : IRequest<IEnumerable<GetSensorDtoResponse>>
    {
    }
}
