using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        services.Configure<JwtTokenSettings>(configuration.GetSection(JwtTokenSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
} 