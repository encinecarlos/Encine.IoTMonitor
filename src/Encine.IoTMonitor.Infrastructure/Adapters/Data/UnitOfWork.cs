using Encine.IoTMonitor.Domain.Interfaces;
using Encine.IoTMonitor.Infrastructure.Adapters.Repositories;
using Encine.IoTMonitor.UseCases.Ports;

namespace Encine.IoTMonitor.Infrastructure.Adapters.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if(_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(_context);
            
            _repositories.Add(typeof(TEntity), repository);
           
            return repository;
        }
    }
}
