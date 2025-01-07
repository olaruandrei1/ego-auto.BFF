using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ego_auto.BFF.Persistence;

public static class PersistenceDependencies
{
    public static void Register(this IServiceCollection services, ConnectionStrings connectionString)
    => services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(connectionString: connectionString.PostgreSql); })
               .AddScoped<IVehicleRepository, VehicleRepository>()
               .AddScoped<IBookingRepository, BookingRepository>()
               .AddScoped<IPaymentRepository, PaymentRepository>()
               .AddScoped<IUserRepository, UserRepository>();
}
