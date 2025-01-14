using ego_auto.BFF.Domain.Common.Bindings;

namespace ego_auto.BFF.AppConfiguration;

public static class ConfigureCors
{
    public static void Policies(this IServiceCollection services, CorsSettings corsSettings)
    => services.AddCors(options =>
    {
        foreach (var policy in corsSettings.Policies)
        {
            options.AddPolicy(policy.Key, policyBuilder =>
            {
                policyBuilder.WithOrigins(policy.Value)
                             .AllowAnyHeader()
                             .AllowAnyMethod();
            });
        }
    });
}
