using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PropertyAPI.Application.Commmon.Interfaces.Authentication;
using PropertyAPI.Application.Commmon.Interfaces.Persistence;
using PropertyAPI.Application.Commmon.Interfaces.Services;
using PropertyAPI.Infrastructure.Authentication;
using PropertyAPI.Infrastructure.Persistence;
using PropertyAPI.Infrastructure.Services;

namespace PropertyAPI.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
        {
        var JwtTokenSettings = new JwtTokenSettings();
        configuration.Bind(JwtTokenSettings.SectionName, JwtTokenSettings);

        services.AddSingleton(Options.Create(JwtTokenSettings));
        // services.Configure<JwtTokenSettings>(configuration.GetSection(JwtTokenSettings.SectionName))
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JwtTokenSettings.Issuer,
                ValidAudience  = JwtTokenSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(JwtTokenSettings.Secret)
                )
            });

        return services;
        }
} 