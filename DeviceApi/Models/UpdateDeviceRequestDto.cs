namespace DeviceApi.Models;

public record UpdateDeviceRequestDto(
    string PrimaryUser,
    string OperatingSystem,
    DeviceType DeviceType,
    DeviceStatus Status);