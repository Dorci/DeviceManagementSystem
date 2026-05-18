using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeviceApi.Models;

public class Device
{
    [Key]
    public Guid SerialNumber { get; set; }
    [ReadOnly(true)]
    public string ModelName { get; set; }
    [ReadOnly(true)]
    public string ModelId { get; set; }
    [ReadOnly(true)]
    public string Manufacturer  { get; set; }
    [EmailAddress]
    public string PrimaryUser { get; set; }
    public string OperatingSystem  { get; set; }
    public DeviceType DeviceType  { get; set; }
    public DeviceStatus Status   { get; set; }
}

public enum DeviceType
{
    Laptop,
    Desktop
}

public enum DeviceStatus
{
    Active,
    InActive,
    Retired
}