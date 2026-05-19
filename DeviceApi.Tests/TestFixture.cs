using DeviceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceApi.Tests;

public class TestFixture
{
    public static DeviceContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<DeviceContext>()
            .UseInMemoryDatabase("TestDeviceDb")
            .Options;

        var context = new DeviceContext(options);
        return context;
    }
}