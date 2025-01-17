namespace Device.API.Contexts.Dtos.Devices;

public class DevicesDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Brand { get; set; }
    public int State { get; set; }
    public DateTime CreationTime { get; set; }
}