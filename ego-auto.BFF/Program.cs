using ego_auto.BFF.Application;
using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Utilities;
using ego_auto.BFF.Infrastructure;
using ego_auto.BFF.Middleware;
using ego_auto.BFF.Persistence;
using Serilog;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(new CompactJsonFormatter(), "logs/{Date}.json", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 10_000_000, rollOnFileSizeLimit: true)
    .CreateLogger();

ApplicationDependencies.Register(builder.Services);
BindConfigurationObjects.Register(builder.Services, builder.Configuration);
PersistenceDependencies.Register
        (
            builder.Services,
            builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>() ?? throw new ArgumentNullException("Connection strings properties are missing from configurable file.")
        );
InfrastructureDependencies.Register
        (
            builder.Services, 
            builder.Configuration.GetSection("AppSettings").Get<AppSettings>() ?? throw new ArgumentNullException("AppSettings properties are missing from configurable file.")
        );

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<TraceMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
