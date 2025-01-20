using Device.API.Contexts.Dtos.Devices;
using System.Linq.Expressions;

namespace Device.API.Repositories.V1;

public interface IDevicesRepository
{
    Task<IEnumerable<DevicesDto>> GetAllAsync();
    Task<DevicesDto?> GetAsync(Expression<Func<DevicesDto, bool>> filter);
    Task<DevicesDto> Insert(DevicesDto device);
    Task<DevicesDto> Update(DevicesDto device);
    Task<bool> Delete(DevicesDto device);
    IQueryable<DevicesDto> Query();
}