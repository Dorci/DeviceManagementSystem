namespace DeviceApi.Models;

public record CreateDeviceRequestDto(
    Guid SerialNumber,
    string ModelName,
    string ModelId,
    string Manufacturer,
    string PrimaryUser,
    string OperatingSystem,
    DeviceType DeviceType,
    DeviceStatus Status);