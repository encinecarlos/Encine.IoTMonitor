using Encine.IoTMonitor.Domain.Enums;
using Encine.IoTMonitor.Domain.ValueObjects;

namespace Encine.IoTMonitor.Domain.Entities
{
    public sealed class Sensor : BaseEntity
    {
        public string Name { get; init; }
        public SensorType Type { get; init; }
        public Coordinates? Location { get; init; }
        public bool Active { get; set; }
        public SensorConfiguration? Configuration { get; set; }

        private Sensor(string name, SensorType type, bool active)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Active = active;
        }

        public static Sensor Create(string name, SensorType type, bool active)
        {
            return new Sensor(name, type, active);
        }
    }
}
