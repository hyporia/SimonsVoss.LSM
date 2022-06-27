using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace SimonsVoss.LSM.Core;

public static class Entry
{
    public static IServiceCollection AddCore(
        this IServiceCollection services)
    {
        services.AddMediatR(typeof(Entry));
        
        return services;
    }
}