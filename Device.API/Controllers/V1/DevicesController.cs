using Device.API.Services.V1.Devices;
using Microsoft.AspNetCore.Mvc;
using Device.API.Models.V1.Devices;
using System.Net;
using Device.API.Contexts.Dtos.Devices;

namespace Device.API.Controllers.V1;

[Route("api/v1/[controller]")]
[ApiController]
public class DevicesController(IDevicesService devicesService) : ControllerBase
{
    private readonly IDevicesService _devicesService = devicesService;

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(IEnumerable<DevicesDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromQuery] DeviceFilter filter)
    {
        var devices = await _devicesService.GetDevices(filter);

        if (!devices.Any())
            return NotFound(devices);

        return Ok(devices);
    }

    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] DeviceCreation device)
    {
        var createdDevice = await _devicesService.Create(device);

        return Ok(createdDevice);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] DeviceUpdate device, int id)
    {
        var updateDevice = await _devicesService.Update(device, id);

        if (updateDevice == null)
            return NotFound();

        return Ok(updateDevice);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _devicesService.Delete(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}