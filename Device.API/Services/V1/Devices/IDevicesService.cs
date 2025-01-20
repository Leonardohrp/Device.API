using Device.API.Contexts.Dtos.Devices;
using Device.API.Models.V1.Devices;

namespace Device.API.Services.V1.Devices;

public interface IDevicesService
{
    Task<bool> Delete(int id);
    Task<DeviceModel> Create(DeviceCreation device);
    Task<DeviceModel?> Update(DeviceUpdate device, int id);
    Task<IEnumerable<DeviceModel>> GetDevices(DeviceFilter filter);
}