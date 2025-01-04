using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Application.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ego_auto.BFF.Application;

public static class ApplicationDependencies
{
    public static void Register(this IServiceCollection services)
    => services.AddScoped<IVehicleService, VehicleService>()
               .AddScoped<IPaymentService, PaymentService>()
               .AddScoped<IUserService, UserService>()
               .AddScoped<IBookingService, BookingService>();
}
