using ego_auto.BFF.Application;
using ego_auto.BFF.Domain;
using ego_auto.BFF.Domain.Common.Bindings;
using ego_auto.BFF.Domain.ExceptionTypes;
using ego_auto.BFF.Infrastructure;
using ego_auto.BFF.Middleware;
using ego_auto.BFF.Persistence;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(new CompactJsonFormatter(), "logs/{Date}.json", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 10_000_000, rollOnFileSizeLimit: true)
    .CreateLogger();

BindConfigurationObjects.Register(builder.Services, builder.Configuration);
ApplicationDependencies.Register(builder.Services);
PersistenceDependencies.Register
        (
            builder.Services,
            connectionStrings ?? throw new CustomNotFound("Connection strings properties are missing from configurable file.")
        );
InfrastructureDependencies.Register
        (
            builder.Services,
            appSettings ?? throw new CustomNotFound("AppSettings properties are missing from configurable file.")
        );
AuthenticationDependencies.Configuration(builder.Services, appSettings.JwtConfiguration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<TraceMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
