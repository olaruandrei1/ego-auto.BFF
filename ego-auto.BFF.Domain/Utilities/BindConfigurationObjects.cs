using ego_auto.BFF.Domain.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ego_auto.BFF.Domain.Utilities;

public static class BindConfigurationObjects
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("AppSettings").Get<AppSettings>()
            ?? throw new InvalidOperationException("AppSettings configuration section is missing."));

        services.AddSingleton(configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>()
            ?? throw new InvalidOperationException("ConnectionStrings configuration section is missing."));
    }
}
