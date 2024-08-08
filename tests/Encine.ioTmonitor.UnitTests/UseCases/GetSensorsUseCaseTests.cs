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
    public class GetSensorsUseCaseTests
    {
        private readonly Mock<ILogger> _loggerMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IRepository<Sensor>> _sensorRepositoryMock;
        private readonly GetSensorsUseCase _getSensorsUseCase;

        public GetSensorsUseCaseTests()
        {
            _loggerMock = new Mock<ILogger>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sensorRepositoryMock = new Mock<IRepository<Sensor>>();

            _unitOfWorkMock.Setup(uow => uow.Repository<Sensor>()).Returns(_sensorRepositoryMock.Object);

            _getSensorsUseCase = new GetSensorsUseCase(_loggerMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnCorrectNumberOfSensorDtos()
        {
            // Arrange
            List<Sensor> sensors = SetupSensors(5);

            _sensorRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sensors);

            var request = new GetSensorDto();

            // Act
            var result = await _getSensorsUseCase.Handle(request, CancellationToken.None);

            // Assert
            result.Should().HaveCount(sensors.Count);
        }

        

        [Fact]
        public async Task Handle_ShouldMapSensorEntitiesToDtosCorrectly()
        {
            // Arrange
            List<Sensor> sensors = SetupSensors(1);

            _sensorRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sensors);

            var request = new GetSensorDto();

            // Act
            var result = await _getSensorsUseCase.Handle(request, CancellationToken.None);

            // Assert
            result.Should().ContainSingle();
            var sensorDto = result.First();
            sensorDto.SensorId.Should().Be(sensors[0].Id);
            sensorDto.Name.Should().Be(sensors[0].Name);
            sensorDto.Type.Should().Be(sensors[0].Type.ToString());
            sensorDto.Active.Should().Be(sensors[0].Active);
        }

        [Fact]
        public async Task Handle_ShouldLogInformationMessage()
        {
            // Arrange
            var sensors = new List<Sensor>();

            _sensorRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sensors);

            var request = new GetSensorDto();

            // Act
            await _getSensorsUseCase.Handle(request, CancellationToken.None);

            // Assert
            _loggerMock.Verify(logger => logger.Information("Getting sensors"), Times.Once);
        }

        private static List<Sensor> SetupSensors(int quantity)
        {
            var sensors = new List<Sensor>();

            for (int i = 0; i < quantity; i++)
            {
                sensors.Add(Sensor.Create($"Sensor{i}", SensorType.Temperature, true));
            }

            return sensors;
        }
    }
}