using Encine.IoTMonitor.Domain.Interfaces;

namespace Encine.IoTMonitor.UseCases.Ports
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
