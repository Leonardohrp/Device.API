using Device.API.Shared.Enums;

namespace Device.API.Models.V1.Devices;

public class DeviceModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Brand { get; set; }
    public required DeviceStates State { get; set; }
    public required DateTime CreationTime { get; set; }
}