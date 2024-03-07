using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EnglishApplication.Extensions;

public static class ConfigurationExtensions
{
    public static void AddSwaggerWithAuth(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "English Application",
                Description = "An application to learn english made for OOP classes",
                Version = "1.3.3.7"
            });

            var schema = new OpenApiSecurityScheme
            {
                Description = "Using the Authorization header with the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            options.AddSecurityDefinition("Bearer", schema);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { schema, new[] { "Bearer" } }
            });
        });
    }
}