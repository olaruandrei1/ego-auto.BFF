using ego_auto.BFF.AppConfiguration;
using ego_auto.BFF.Application;
using ego_auto.BFF.Domain;
using ego_auto.BFF.Domain.Common.Bindings;
using ego_auto.BFF.Domain.ExceptionTypes;
using ego_auto.BFF.Infrastructure;
using ego_auto.BFF.Persistence;

namespace ego_auto.BFF.Utilities;

public static class DependencyInjectionOrchestration
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
        var connectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
        var corsSettings = configuration.GetSection("CorsSettings").Get<CorsSettings>();

        BindConfigurationObjects.Register(services, configuration);
        ApplicationDependencies.Register(services);
        PersistenceDependencies.Register
                (
                    services,
                    connectionStrings ?? throw new CustomNotFound("Connection strings properties are missing from configurable file.")
                );
        InfrastructureDependencies.Register
                (
                    services,
                    appSettings ?? throw new CustomNotFound("AppSettings properties are missing from configurable file.")
                );
        AuthenticationDependencies.Configuration(services, appSettings.JwtConfiguration);

        ConfigureCors.Policies(services, corsSettings);

        SwaggerConfiguration.AdditionalSettings(services);
    }
}
