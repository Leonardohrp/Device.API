using Device.API.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Device.API.Models.V1.Devices;

public class DeviceCreation(string name, string brand, DeviceStates state)
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = name;

    [Required]
    [StringLength(100)]
    public string Brand { get; set; } = brand;

    [Required]
    [Range(1, 3)]
    public DeviceStates State { get; set; } = state;

    [JsonIgnore]
    public DateTime CreationTime { get; set; } = DateTime.Now;
}
