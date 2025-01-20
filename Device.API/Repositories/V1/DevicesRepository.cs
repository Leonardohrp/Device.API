using Device.API.Contexts;
using Device.API.Contexts.Dtos.Devices;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Device.API.Repositories.V1;

public class DevicesRepository(DevicesDbContext context) : IDevicesRepository
{
    private readonly DevicesDbContext _context = context;

    public async Task<DevicesDto?> GetAsync(Expression<Func<DevicesDto, bool>> filter) =>
        await _context.Devices
                      .Where(filter)  
                      .FirstOrDefaultAsync(); 

    public async Task<IEnumerable<DevicesDto>> GetAllAsync() =>
        await _context.Devices.ToListAsync();

    public async Task<DevicesDto> Insert(DevicesDto device)
    {
        _context.Add(device);
        await _context.SaveChangesAsync();

        return device;
    }

    public async Task<DevicesDto> Update(DevicesDto device)
    {
        _context.Devices.Update(device);
        await _context.SaveChangesAsync();

        return device;
    }

    public async Task<bool> Delete(DevicesDto device)
    {
        _context.Devices.Remove(device);
        await _context.SaveChangesAsync();

        return true;
    }

    public IQueryable<DevicesDto> Query() =>
        _context.Devices.AsQueryable();
}