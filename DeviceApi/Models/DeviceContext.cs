using Microsoft.EntityFrameworkCore;

namespace DeviceApi.Models;

public class DeviceContext : DbContext
{
    public DeviceContext(DbContextOptions<DeviceContext> options)
        : base(options)
    {
    }

    public DbSet<Device> Devices { get; set; } = null!;
}