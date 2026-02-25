using EverWave.Domain.Common;
using EverWave.Domain.Services.ApiServices;
using EverWave.Services.ApiServices;

using Microsoft.Extensions.DependencyInjection;

using TimeProvider = EverWave.Services.Common.TimeProvider;

namespace EverWave.Services.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddTransient<IUnidadeService, UnidadeService>();
        return services;
    }

    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddTransient<ITimeProvider, TimeProvider>();
        return services;
    }
}