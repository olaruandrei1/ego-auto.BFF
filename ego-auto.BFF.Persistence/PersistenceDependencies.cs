using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ego_auto.BFF.Persistence;

public static class PersistenceDependencies
{
    public static void Register(this IServiceCollection services, string connectionString)
    => services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(connectionString); })
               .AddScoped<IVehicleRepository, VehicleRepository>()
               .AddScoped<IBookingRepository, BookingRepository>()
               .AddScoped<IPaymentRepository, PaymentRepository>()
               .AddScoped<IUserRepository, UserRepository>();
}
