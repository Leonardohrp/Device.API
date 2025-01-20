using Device.API.Shared.Enums;

namespace Device.API.Models.V1.Devices;

public record DeviceFilter(int? Id, string? Brand, DeviceStates? State)
{
}