using Encine.IoTMonitor.Domain.Entities;
using Encine.IoTMonitor.Domain.Interfaces;
using Encine.IoTMonitor.Infrastructure.Adapters.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Encine.IoTMonitor.Infrastructure.Adapters.Repositories
{
    public sealed class SensorRepository
    {
        private readonly DataContext _context;

        public SensorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Sensor> CreateSensor(Sensor sensor)
        {
            await _context.Sensors.AddAsync(sensor);
            return sensor;
        }

        public async Task DeleteSensor(Guid id)
        {
            var sensor = await _context.Sensors.FindAsync(id);

            if (sensor == null)
            {
                throw new Exception("Sensor not found");
            }

            _context.Sensors.Remove(sensor);
        }

        public async Task<IEnumerable<Sensor>> GetAllSensors()
        {
            return await _context.Sensors.ToListAsync();
        }

        public async Task<Sensor?> GetSensorById(Guid id) 
            => await _context.Sensors.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateSensor(Sensor sensor)
        {
            var sensorUpdate = await _context.Sensors.FindAsync(sensor.Id);

            if (sensorUpdate == null)
            {
                throw new Exception("Sensor not found");
            }

            _context.Entry(sensorUpdate).CurrentValues.SetValues(sensor);
        }
    }
}
