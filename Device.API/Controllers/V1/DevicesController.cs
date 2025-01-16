using Device.API.Services.V1.Devices;
using Microsoft.AspNetCore.Mvc;

namespace Device.API.Controllers.V1;

[ApiExplorerSettings(GroupName = "v1.Devices")]
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
