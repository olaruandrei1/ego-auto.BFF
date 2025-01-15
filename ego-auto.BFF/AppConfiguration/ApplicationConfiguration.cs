using ego_auto.BFF.Domain.Common.Bindings;
using ego_auto.BFF.Middleware;

namespace ego_auto.BFF.AppConfiguration;

public static class ApplicationConfiguration
{
    public static void PreBuild(this WebApplication app, IConfiguration configuration)
    {
        app.UseSwagger()
              .UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ego.Auto.BFF-API");
              })
              .UseMiddleware<TraceMiddleware>()
              .UseHttpsRedirection()
              .UseAuthentication()
              .UseAuthorization();

        app.MapControllers();

        var corsSettings = configuration.GetSection("CorsSettings").Get<CorsSettings>().Policies;

        foreach (string corsPolicy in corsSettings.Keys) app.UseCors(corsPolicy);
    }
}
