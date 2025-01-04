using ego_auto.BFF.Domain.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ego_auto.BFF.Domain.Utilities;

public static class BindConfigurationObjects
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    =>
        services.AddSingleton(configuration.GetSection("AppSettings").Get<AppSettings>())
                .AddSingleton(configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>());
}
