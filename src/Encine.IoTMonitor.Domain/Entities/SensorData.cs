using Encine.IoTMonitor.Domain.Enums;

namespace Encine.IoTMonitor.Domain.Entities
{
    public sealed class SensorData : BaseEntity
    {
        public Guid SensorId { get; init; }
        public string Value { get; init; }
        public DateTimeOffset Date { get; init; }
        public SensorUnit Unit { get; init; }
    }
}
