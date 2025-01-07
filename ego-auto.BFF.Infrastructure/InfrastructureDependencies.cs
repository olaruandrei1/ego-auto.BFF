using ego_auto.BFF.Application.Contracts.Infrastructure;
using ego_auto.BFF.Domain.Common.Bindings;
using ego_auto.BFF.Infrastructure.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ego_auto.BFF.Infrastructure;
public static class InfrastructureDependencies
{
    public static void Register(this IServiceCollection services, AppSettings appsettings)
    {
        string? paymentsClient = appsettings.PaymentConfiguration!.HttpClientName;

        if (!string.IsNullOrEmpty(paymentsClient))
            services.AddHttpClient(appsettings.PaymentConfiguration!.HttpClientName!, client =>
            {
                client.BaseAddress = new Uri(appsettings.PaymentConfiguration!.BaseUrl!);
            });

        services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();
    }
}
