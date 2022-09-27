using MicroservicesPlayground.PlatformService.Dtos;

namespace MicroservicesPlayground.PlatformService.SyncDataService.Http;

public interface ICommandDataClient
{
    Task SendPlatformToCommand(PlatformReadDto platformReadDto);
}
