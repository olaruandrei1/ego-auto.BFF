using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Infrastructure.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ego_auto.BFF.Infrastructure;
public static class InfrastructureDependencies
{
    public static void Register(this IServiceCollection services)
    => services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();
}
