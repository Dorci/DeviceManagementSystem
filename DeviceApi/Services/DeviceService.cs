using DeviceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceApi.Services;

public class DeviceService : IDeviceService
{
    private readonly DeviceContext _context;

    public DeviceService(DeviceContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<DeviceResponseDto>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Devices
            .Select(device => ToResponse(device))
            .ToListAsync(ct);
    }

    public async Task<DeviceResponseDto?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var device = await _context.Devices
            .FirstOrDefaultAsync(device => device.SerialNumber == id, ct);
        return device is null ? null : ToResponse(device);
    }

    public async Task<DeviceResponseDto> CreateAsync(CreateDeviceRequestDto request, CancellationToken ct)
    {
        var device = new Device
        {
            SerialNumber = Guid.NewGuid(),
            ModelName = request.ModelName,
            ModelId = request.ModelId,
            Manufacturer = request.Manufacturer,
            PrimaryUser = request.PrimaryUser,
            OperatingSystem = request.OperatingSystem,
            DeviceType = request.DeviceType,
            Status = request.Status,
        };

        _context.Devices.Add(device);
        await _context.SaveChangesAsync(ct);

        return ToResponse(device);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateDeviceRequestDto request, CancellationToken ct)
    {
        var device = await _context.Devices.FindAsync([id], ct);
        if (device is null) return false;

        device.PrimaryUser = request.PrimaryUser;
        device.OperatingSystem = request.OperatingSystem;
        device.DeviceType = request.DeviceType;
        device.Status = request.Status;

        await _context.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
    {
        var device = await _context.Devices.FindAsync([id], ct);
        if (device is null) return false;

        _context.Devices.Remove(device);
        await _context.SaveChangesAsync(ct);
        return true;
    }

    private static DeviceResponseDto ToResponse(Device device)
    {
        return new DeviceResponseDto(device.SerialNumber, device.ModelName, device.ModelId, device.Manufacturer,
            device.PrimaryUser, device.OperatingSystem, device.DeviceType, device.Status);
    }
}