using DeviceApi.Models;
using DeviceApi.Services;
using FluentAssertions;

namespace DeviceApi.Tests;

public class DeviceRegistrationTests
{
    [Fact]
    public async Task Register_new_device()
    {
        // Arrange
        await using var context = TestFixture.CreateContext();
        var service = new DeviceService(context);
        var device = TestDevice();

        // Act
        var result = await service.CreateAsync(
            new CreateDeviceRequestDto(
                device.ModelName,
                device.ModelId,
                device.Manufacturer,
                device.PrimaryUser,
                device.OperatingSystem,
                device.DeviceType,
                device.Status
            ),
            CancellationToken.None
        );

        // Assert
        result.Should().NotBeNull();
        result.ModelName.Should().Be(device.ModelName);
        result.ModelId.Should().Be(device.ModelId);
        result.Manufacturer.Should().Be(device.Manufacturer);
        result.PrimaryUser.Should().Be(device.PrimaryUser);
        result.OperatingSystem.Should().Be(device.OperatingSystem);
        result.DeviceType.Should().Be(device.DeviceType);
        result.Status.Should().Be(DeviceStatus.Active);
    }

    private static Device TestDevice()
    {
        return new Device
        {
            ModelName = "Lava",
            ModelId = "43xk",
            Manufacturer = "Lenovo",
            PrimaryUser = "alice@example.com",
            OperatingSystem = "Windows 11",
            DeviceType = DeviceType.Laptop,
            Status = DeviceStatus.Active
        };
    }
}