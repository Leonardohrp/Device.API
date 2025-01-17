
using Device.API.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Device.API.Repositories.V1;

public class DevicesRepository(DevicesDbContext context) : IDevicesRepository
{
    private readonly DevicesDbContext _context = context;
    public async Task GetAll()
    {
        var a = await _context.Devices.Where(_ => true).ToListAsync();
        var b = "";
    }
}