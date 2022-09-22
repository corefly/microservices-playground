using AutoMapper;
using MicroservicesPlayground.PlatformService.Dtos;
using MicroservicesPlayground.PlatformService.Models;

namespace MicroservicesPlayground.PlatformService.Profiles;

public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<PlatformCreateDto, Platform>();
    }
}
