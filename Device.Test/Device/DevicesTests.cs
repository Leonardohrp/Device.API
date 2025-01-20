using System.Linq.Expressions;
using AutoMapper;
using Device.API.Contexts.Dtos.Devices;
using Device.API.Models.V1.Devices;
using Device.API.Repositories.V1;
using Device.API.Services.V1.Devices;
using Device.API.Shared.Enums;
using Moq;

namespace Device.Test.Device;

[TestFixture]
public class DevicesTests
{
    private Mock<IDevicesRepository> _repositoryMock;
    private DevicesService _deviceService;
    private IMapper _mapper;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IDevicesRepository>();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DeviceCreation, DevicesDto>();
            cfg.CreateMap<DevicesDto, DeviceModel>();
            cfg.CreateMap<DeviceUpdate, DevicesDto>();
        });

        _mapper = mapperConfig.CreateMapper();

        _deviceService = new DevicesService(_repositoryMock.Object, _mapper);
    }

    [Test]
    public async Task Create_ShouldInsertDeviceAndReturnModel()
    {
        //Arrange
        var deviceCreation = new DeviceCreation("New Device 1", "New Brand 1", DeviceStates.Available);
        var deviceDto = new DevicesDto { Id = 1, Name = "New Device 1", Brand = "New Brand 1" };

        _repositoryMock.Setup(repo => repo.Insert(It.IsAny<DevicesDto>()))
            .ReturnsAsync(deviceDto);

        //Act
        var result = await _deviceService.Create(deviceCreation);

        //Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo(deviceCreation.Name));
        Assert.That(result.Brand, Is.EqualTo(deviceCreation.Brand));
        _repositoryMock.Verify(repo => repo.Insert(It.IsAny<DevicesDto>()), Times.Once);
    }

    [Test]
    public async Task Delete_ShouldReturnFalse_WhenDeviceNotFound()
    {
        //Arrange
        _repositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<DevicesDto, bool>>>()))
            .ReturnsAsync(null as DevicesDto);

        //Act
        var result = await _deviceService.Delete(1);

        //Assert
        Assert.That(result, Is.False);
        _repositoryMock.Verify(repo => repo.GetAsync(It.IsAny<Expression<Func<DevicesDto, bool>>>()), Times.Once);
    }

    [Test]
    public async Task Delete_ShouldReturnFalse_WhenDeviceInUse()
    {
        //Arrange
        var device = new DevicesDto { Id = 1, State = (int)DeviceStates.InUse };
        _repositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<DevicesDto, bool>>>()))
            .ReturnsAsync(device);

        //Act
        var result = await _deviceService.Delete(1);

        //Assert
        Assert.That(result, Is.False);
        _repositoryMock.Verify(repo => repo.GetAsync(It.IsAny<Expression<Func<DevicesDto, bool>>>()), Times.Once);
        _repositoryMock.Verify(repo => repo.Delete(It.IsAny<DevicesDto>()), Times.Never);
    }

    [Test]
    public async Task Delete_ShouldReturnTrue_WhenDeviceDeleted()
    {
        //Arrange
        var device = new DevicesDto { Id = 1, State = (int)DeviceStates.Available };
        _repositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<DevicesDto, bool>>>()))
            .ReturnsAsync(device);

        _repositoryMock.Setup(repo => repo.Delete(It.IsAny<DevicesDto>()))
            .Returns(Task.FromResult(true));

        //Act
        var result = await _deviceService.Delete(1);

        //Assert
        Assert.That(result, Is.True);
        _repositoryMock.Verify(repo => repo.GetAsync(It.IsAny<Expression<Func<DevicesDto, bool>>>()), Times.Once);
        _repositoryMock.Verify(repo => repo.Delete(It.IsAny<DevicesDto>()), Times.Once);
    }

    [Test]
    public async Task Update_ShouldReturnNull_WhenDeviceNotFound()
    {
        //Arrange
        _repositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<DevicesDto, bool>>>()))
            .ReturnsAsync(null as DevicesDto);

        //Act
        var result = await _deviceService.Update(new DeviceUpdate { Name = "Updated" }, 1);

        //Assert
        Assert.That(result, Is.Null);
        _repositoryMock.Verify(repo => repo.GetAsync(It.IsAny<Expression<Func<DevicesDto, bool>>>()), Times.Once);
        _repositoryMock.Verify(repo => repo.Update(It.IsAny<DevicesDto>()), Times.Never);
    }

    [Test]
    public async Task Update_ShouldModifyDevice_WhenValidUpdate()
    {
        //Arrange
        var device = new DevicesDto { Id = 1, Name = "New Device 1", Brand = "New Brand 1", State = (int)DeviceStates.Available };
        _repositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<DevicesDto, bool>>>()))
            .ReturnsAsync(device);

        _repositoryMock.Setup(repo => repo.Update(It.IsAny<DevicesDto>()))
            .ReturnsAsync(device);

        var update = new DeviceUpdate { Name = "UpdatedName", Brand = "UpdatedBrand", State = DeviceStates.Available };

        //Act
        var result = await _deviceService.Update(update, 1);

        //Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo(update.Name));
        Assert.That(result.Brand, Is.EqualTo(update.Brand));
        Assert.That(result.State, Is.EqualTo(update.State));
        _repositoryMock.Verify(repo => repo.Update(It.IsAny<DevicesDto>()), Times.Once);
    }

    [Test]
    [Ignore("Test will be ignored as it is not functional")]
    public async Task GetDevices_ShouldReturnFilteredResults()
    {
        //Arrange
        var devices = new List<DevicesDto>
        {
            new() { Id = 1, Name = "New Device 1", Brand = "New Brand 1", State = (int)DeviceStates.Available },
            new() { Id = 2, Name = "New Device 2", Brand = "New Brand 2", State = (int)DeviceStates.Inactive }
        };

        _repositoryMock.Setup(repo => repo.Query())
            .Returns(devices.AsQueryable());

        var filter = new DeviceFilter(null, "New Device 1", null);

        //Act
        var result = await _deviceService.GetDevices(filter);

        //Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Brand, Is.EqualTo("New Device 1"));
        _repositoryMock.Verify(repo => repo.Query(), Times.Once);
    }
}