using Device.API.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Device.API.Models.V1.Devices;

public class DeviceUpdate
{
    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(100)]
    public string? Brand { get; set; }

    [Range(1, 3)]
    public DeviceStates? State { get; set; }
}
