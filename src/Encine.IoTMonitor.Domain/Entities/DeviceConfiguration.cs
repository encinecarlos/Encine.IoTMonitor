namespace Encine.IoTMonitor.Domain.Entities
{
    public sealed class DeviceConfiguration : BaseEntity
    {
        public Guid SensorId { get; init; }
        public string Settings { get; set; }
    }
}
