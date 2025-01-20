using AutoMapper;
using Device.API.Contexts.Dtos.Devices;
using Device.API.Models.V1.Devices;

namespace Device.API.Mappings.V1;

public class DevicesMappingProfile : Profile
{
    public DevicesMappingProfile()
    {
        CreateMap<DeviceCreation, DevicesDto>()
            .ForMember(d => d.Name, o => o.MapFrom(x => x.Name))
            .ForMember(d => d.Brand, o => o.MapFrom(x => x.Brand))
            .ForMember(d => d.State, o => o.MapFrom(x => (int)x.State))
            .ForMember(d => d.CreationTime, o => o.MapFrom(x => x.CreationTime));

        CreateMap<DevicesDto, DeviceModel>()
            .ForMember(d => d.Id, o => o.MapFrom(x => x.Id))
            .ForMember(d => d.Name, o => o.MapFrom(x => x.Name))
            .ForMember(d => d.Brand, o => o.MapFrom(x => x.Brand))
            .ForMember(d => d.State, o => o.MapFrom(x => x.State))
            .ForMember(d => d.CreationTime, o => o.MapFrom(x => x.CreationTime));
    }
}