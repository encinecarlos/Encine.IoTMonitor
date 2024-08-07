namespace Encine.IoTMonitor.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? LastUpdateDate { get; set; }
    }
}
