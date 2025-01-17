using Device.API.Contexts.Dtos.Devices;
using Microsoft.EntityFrameworkCore;

namespace Device.API.Contexts;

public class DevicesDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<DevicesDto> Devices { get; set; }
}