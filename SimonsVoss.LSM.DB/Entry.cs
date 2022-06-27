using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimonsVoss.LSM.DB;

public static class Entry
{
    public static IServiceCollection AddPostgreSql(
        this IServiceCollection services,
        string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException(nameof(connectionString));

        services.AddDbContext<EfContext>(opt =>
        {
            opt.UseSnakeCaseNamingConvention();
            opt.UseNpgsql(connectionString);
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        });
        
        return services;
    }
}