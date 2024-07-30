using Encine.IoTMonitor.Domain.Enums;

namespace Encine.IoTMonitor.Domain.Entities
{
    public sealed class Alert : BaseEntity
    {
        public Guid SensorId { get; init; }
        public DateTimeOffset Timestamp { get; init; }
        public string Message { get; init; }
        public AlertLevel Severity { get; init; }
    }
}
