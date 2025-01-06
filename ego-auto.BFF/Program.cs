using ego_auto.BFF.Application;
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

//BindConfigurationObjects.Register(builder.Services, builder.Configuration);
PersistenceDependencies.Register
        (
            builder.Services,
            connectionString: builder.Configuration.GetConnectionString("PostgreSql")
        );
ApplicationDependencies.Register(builder.Services);
InfrastructureDependencies.Register(builder.Services);

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
