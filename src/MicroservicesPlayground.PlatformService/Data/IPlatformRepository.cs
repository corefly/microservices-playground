using MicroservicesPlayground.PlatformService.Models;

namespace MicroservicesPlayground.PlatformService.Data;

public interface IPlatformRepository
{
    Task<bool> SaveChanges();

    ICollection<Platform> GetAllPlatforms();
    Task<Platform?> GetPlatform(int id);
    Task CreatePlatform(Platform platform);
}
