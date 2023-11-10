using Microsoft.Extensions.DependencyInjection;
using PropertyAPI.Application.Commmon.Interfaces.Authentication;
using PropertyAPI.Application.Commmon.Interfaces.Services;
using PropertyAPI.Infrastructure.Authentication;
using PropertyAPI.Infrastructure.Services;

namespace PropertyAPI.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services){
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
} 