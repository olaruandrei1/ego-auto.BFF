using Microsoft.OpenApi.Models;

namespace ego_auto.BFF.AppConfiguration;

public static class SwaggerConfiguration
{
    public static void AdditionalSettings(this IServiceCollection services)
    => services.AddSwaggerGen
                (
                    c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo
                            {
                                Title = "Ego.Auto.BFF-API",
                                Version = "v1",
                                Description = "BackendForFrontend APIs destinated for ego-auto booking vehicles web application.",
                                Contact = new OpenApiContact
                                {
                                    Name = "Ego Auto Support",
                                    Email = "support@egoauto.com"
                                }
                            });

                            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                            {
                                Description = @"Enter jwt bearer:",
                                Name = "Authorization",
                                In = ParameterLocation.Header,
                                Type = SecuritySchemeType.ApiKey,
                                Scheme = "Bearer"
                            });

                            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                            {
                                {
                                    new OpenApiSecurityScheme
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"
                                        },
                                        Scheme = "oauth2",
                                        Name = "Bearer",
                                        In = ParameterLocation.Header,
                                    },
                                    new List<string>()
                                }
                            });
                        }
                );
}
