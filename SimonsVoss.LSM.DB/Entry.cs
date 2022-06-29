using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.DB.Repositories;

namespace SimonsVoss.LSM.DB;

public static class Entry
{
    public static IServiceCollection AddPostgreSql(
        this IServiceCollection services,
        Action<PostgresDbOptions>? optionsAction)
    {
        var options = new PostgresDbOptions();
        optionsAction?.Invoke(options);

        return services.AddPostgreSql(options);
    }

    public static IServiceCollection AddPostgreSql(
        this IServiceCollection services,
        PostgresDbOptions options)
    {
        if (options == null) throw new ArgumentNullException(nameof(options));

        if (string.IsNullOrWhiteSpace(options.ConnectionString))
            throw new ArgumentException(nameof(options.ConnectionString));

        services.AddDbContext<EfContext>(opt =>
        {
            if (options?.SqlLoggerFactory != null)
                opt.UseLoggerFactory(options.SqlLoggerFactory);

            opt.UseSnakeCaseNamingConvention();
            opt.UseNpgsql(options!.ConnectionString!);
        });
        
        services.AddTransient<ILockRepository, LockRepository>();
        services.AddTransient<ISearchingWeightsRepository, SearchingWeightsRepository>();

        return services;
    }
}