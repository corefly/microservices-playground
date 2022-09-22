using MicroservicesPlayground.PlatformService.Models;

namespace MicroservicesPlayground.PlatformService.Data;

public static class PreparationDb
{
    public static void PopulateDb(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<PlatformDbContext>();

        SeedData(dbContext);
    }

    private static void SeedData(PlatformDbContext context)
    {
        var isEmptyPlatforms = !context.Platforms.Any();

        if (isEmptyPlatforms)
        {
            context.Platforms.AddRange(new Platform[]
            {
                new() {Id = 1, Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                new() {Id = 2, Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free"},
                new() {Id = 3, Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free"},
            });
            context.SaveChanges();
        }
    }
}
