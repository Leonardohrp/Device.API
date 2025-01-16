using Device.API.Services.V1.Devices;
using Microsoft.AspNetCore.Mvc;

namespace Device.API.Controllers.V1;

/// <summary>
/// 
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class DevicesController(IDevicesService devicesService) : ControllerBase
{
    private readonly IDevicesService _devicesService = devicesService;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> GetDevices()
    {
        return Ok();
    }
}
