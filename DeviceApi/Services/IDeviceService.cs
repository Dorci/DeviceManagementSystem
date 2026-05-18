using DeviceApi.Models;

namespace DeviceApi.Services;

public interface IDeviceService
{
    Task<IReadOnlyList<DeviceResponseDto>> GetAllAsync(CancellationToken ct);
    Task<DeviceResponseDto?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<DeviceResponseDto> CreateAsync(CreateDeviceRequestDto request, CancellationToken ct);
    Task<bool> UpdateAsync(Guid id, UpdateDeviceRequestDto request, CancellationToken ct);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct);

}