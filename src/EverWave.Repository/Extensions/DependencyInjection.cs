using EverWave.Domain.Repository;

using Microsoft.Extensions.DependencyInjection;

namespace EverWave.Repository.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUnidadeRepository, UnidadeRepository>();
        return services;
    }
}