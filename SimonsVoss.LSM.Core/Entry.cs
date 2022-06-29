using Microsoft.Extensions.DependencyInjection;
using MediatR;
using SimonsVoss.LSM.Core.Abstractions;
using SimonsVoss.LSM.Core.AutoMapper;
using SimonsVoss.LSM.Core.Services;

namespace SimonsVoss.LSM.Core;

public static class Entry
{
    public static IServiceCollection AddCore(
        this IServiceCollection services)
    {
        services.AddTransient<IWeightsCalculator, WeightsCalculator>();
        services.AddMediatR(typeof(Entry));
        services.AddAutoMapper(options => { options.AddProfile(new MappingProfile()); });
        
        return services;
    }
}