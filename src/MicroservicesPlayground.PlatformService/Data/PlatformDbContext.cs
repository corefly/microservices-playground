using MicroservicesPlayground.PlatformService.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesPlayground.PlatformService.Data;

public class PlatformDbContext : DbContext
{
    public DbSet<Platform> Platforms { get; set; }

    public PlatformDbContext(DbContextOptions<PlatformDbContext> opt) : base(opt)
    {

    }
}
