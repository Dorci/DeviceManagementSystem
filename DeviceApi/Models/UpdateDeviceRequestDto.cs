namespace DeviceApi.Models;

public record UpdateDeviceRequestDto(
    string PrimaryUser,
    string OperatingSystem,
    DeviceStatus Status);