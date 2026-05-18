namespace DeviceApi.Models;

public record DeviceResponseDto(
    Guid SerialNumber,
    string ModelName,
    string ModelId,
    string Manufacturer,
    string PrimaryUser,
    string OperatingSystem,
    DeviceType DeviceType,
    DeviceStatus Status);