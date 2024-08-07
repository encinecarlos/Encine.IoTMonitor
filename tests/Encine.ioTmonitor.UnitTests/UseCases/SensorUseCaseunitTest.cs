using Encine.IoTMonitor.Domain.Entities;
using Encine.IoTMonitor.Domain.Enums;
using Encine.IoTMonitor.UseCases.Dtos;
using Encine.IoTMonitor.UseCases.Ports;
using Encine.IoTMonitor.UseCases.SensorUseCase;
using FluentAssertions;
using Moq;
using Serilog;

namespace Encine.ioTmonitor.UnitTests.UseCases
{
    public class SensorUseCaseunitTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<ILogger> _logger;
        private readonly SensorHandlerUseCase _sensorHandlerUseCase;

        public SensorUseCaseunitTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _logger = new Mock<ILogger>();
            _sensorHandlerUseCase = new SensorHandlerUseCase(_unitOfWork.Object, _logger.Object);
        }

        [Fact]
        public async Task SensorHandlerUseCase_CreateSensor()
        {
            // Arrange
            var sensorDto = new SensorDto(

                "Sensor 1",
                SensorType.WindDirection,
                true
            );

            _unitOfWork.Setup(x => x.Repository<Sensor>().CreateAsync(It.IsAny<Sensor>()));

            // Act
            var result = await _sensorHandlerUseCase.Handle(sensorDto, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.SensorId.Should().NotBeEmpty();
        }
    }
}
