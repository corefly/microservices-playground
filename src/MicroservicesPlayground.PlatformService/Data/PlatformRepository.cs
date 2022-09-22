using MicroservicesPlayground.PlatformService.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesPlayground.PlatformService.Data;

public class PlatformRepository : IPlatformRepository
{
    private readonly PlatformDbContext _context;

    public PlatformRepository(PlatformDbContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

    public ICollection<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Task<Platform?> GetPlatform(int id)
    {
        return _context.Platforms.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task CreatePlatform(Platform platform)
    {
        await _context.Platforms.AddAsync(platform);
    }
}
