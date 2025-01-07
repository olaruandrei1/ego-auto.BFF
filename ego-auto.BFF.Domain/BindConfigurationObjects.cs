using ego_auto.BFF.Domain.Common.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ego_auto.BFF.Domain;

public static class BindConfigurationObjects
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(options => configuration.GetSection(AppSettings.Key).Bind(options));

        services.Configure<ConnectionStrings>(options => configuration.GetSection(ConnectionStrings.Key).Bind(options));
    }
}
