using Encine.IoTMonitor.Domain.Enums;
using System;

namespace Encine.IoTMonitor.UseCases.Dtos
{
    public record GetSensorDtoResponse(
        Guid SensorId,
        string Name,
        string Type,
        bool Active);
    
}