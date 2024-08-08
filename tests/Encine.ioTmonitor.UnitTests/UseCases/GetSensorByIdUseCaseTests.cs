using Encine.IoTMonitor.Domain.Entities;
using Encine.IoTMonitor.Domain.Enums;
using Encine.IoTMonitor.Domain.Interfaces;
using Encine.IoTMonitor.UseCases.Dtos;
using Encine.IoTMonitor.UseCases.Ports;
using Encine.IoTMonitor.UseCases.SensorUseCase.Queries;
using FluentAssertions;
using Moq;
using Serilog;

namespace Encine.ioTmonitor.UnitTests.UseCases
{
    public class GetSensorByIdUseCaseTests
    {
        private readonly Mock<ILogger> _loggerMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IRepository<Sensor>> _sensorRepositoryMock;
        private readonly GetSensorByIdUseCase _getSensorByIdUseCase;

        public GetSensorByIdUseCaseTests()
        {
            _loggerMock = new Mock<ILogger>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sensorRepositoryMock = new Mock<IRepository<Sensor>>();

            _unitOfWorkMock.Setup(uow => uow.Repository<Sensor>()).Returns(_sensorRepositoryMock.Object);

            _getSensorByIdUseCase = new GetSensorByIdUseCase(_loggerMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnCorrectSensorDto()
        {
            // Arrange
            var sensorId = Guid.NewGuid();
            var sensor = Sensor.Create("Sensor1", SensorType.Temperature, true);

            _sensorRepositoryMock.Setup(repo => repo.GetById(sensorId)).ReturnsAsync(sensor);

            var request = new GetSensorByIdDto(sensorId);

            // Act
            var result = await _getSensorByIdUseCase.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.SensorId.Should().Be(sensor.Id);
            result.Name.Should().Be(sensor.Name);
            result.Type.Should().Be(sensor.Type.ToString());
            result.Active.Should().Be(sensor.Active);
        }

        [Fact]
        public async Task Handle_ShouldLogInformationMessage()
        {
            // Arrange
            var sensorId = Guid.NewGuid();
            var sensor = Sensor.Create("Sensor1", SensorType.Temperature, true);

            _sensorRepositoryMock.Setup(repo => repo.GetById(sensorId)).ReturnsAsync(sensor);

            var request = new GetSensorByIdDto(sensorId);

            // Act
            await _getSensorByIdUseCase.Handle(request, CancellationToken.None);

            // Assert
            _loggerMock.Verify(logger => logger.Information($"Getting sensor by id: {sensorId}"), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnNullIfSensorNotFound()
        {
            // Arrange
            var sensorId = Guid.NewGuid();

            _sensorRepositoryMock.Setup(repo => repo.GetById(sensorId)).ReturnsAsync(null as Sensor);

            var request = new GetSensorByIdDto(sensorId);

            // Act
            var result = await _getSensorByIdUseCase.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }
    }
}