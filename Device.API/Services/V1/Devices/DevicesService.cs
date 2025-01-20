using AutoMapper;
using Device.API.Contexts.Dtos.Devices;
using Device.API.Models.V1.Devices;
using Device.API.Repositories.V1;
using Device.API.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace Device.API.Services.V1.Devices;

public class DevicesService(
    IDevicesRepository repository, 
    IMapper mapper) : IDevicesService
{
    private readonly IMapper _mapper = mapper;
    private readonly IDevicesRepository _repository = repository;

    public async Task<DeviceModel> Create(DeviceCreation device)
    {
        var deviceCreation = _mapper.Map<DevicesDto>(device);
        var deviceModel = await _repository.Insert(deviceCreation);

        return _mapper.Map<DeviceModel>(deviceModel);
    }

    public async Task<bool> Delete(int id)
    {
        var device = await _repository.GetAsync(x => x.Id == id);

        if (device == null || device?.State == (int)DeviceStates.InUse)
            return false;

        await _repository.Delete(device!);

        return true;
    }

    public async Task<DeviceModel?> Update(DeviceUpdate device, int id)
    {
        var deviceUpdate = await _repository.GetAsync(x => x.Id == id);

        if (deviceUpdate == null)
            return null;

        if (deviceUpdate!.State != (int)DeviceStates.InUse)
        {
            deviceUpdate.Name = device.Name ?? deviceUpdate.Name;
            deviceUpdate.Brand = device.Brand ?? deviceUpdate.Brand;
        }
       
        deviceUpdate.State = device.State.HasValue ? (int)device.State : deviceUpdate.State;

        deviceUpdate =  await _repository.Update(deviceUpdate);

        return _mapper.Map<DeviceModel>(deviceUpdate);
    }

    public async Task<IEnumerable<DeviceModel>> GetDevices(DeviceFilter filter)
    {
        var query = _repository.Query();

        if (filter!.Id.HasValue)
            query = query.Where(x => x.Id == filter.Id.Value);

        if (!string.IsNullOrEmpty(filter?.Brand))
            query = query.Where(x => x.Brand == filter.Brand);

        if (filter!.State.HasValue)
            query = query.Where(x => x.State == (int)filter.State.Value);

        var devices = await query.ToListAsync();
        return _mapper.Map<IEnumerable<DeviceModel>>(devices);
    }
}