using Encine.IoTMonitor.Domain.Enums;
using Encine.IoTMonitor.Domain.ValueObjects;

namespace Encine.IoTMonitor.Domain.Entities
{
    public sealed class Sensor : BaseEntity
    {
        public string Name { get; init; }
        public SensorType Type { get; init; }
        public Coordinates Location { get; init; }
        public bool Active { get; set; }
        public DeviceConfiguration Configuration { get; set; }
    }
}
