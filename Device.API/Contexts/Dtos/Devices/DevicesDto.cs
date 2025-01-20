namespace Device.API.Contexts.Dtos.Devices;

public class DevicesDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public int State { get; set; }
    public DateTime CreationTime { get; set; }
}