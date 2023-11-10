using Microsoft.Extensions.DependencyInjection;
using PropertyAPI.Application.Commmon.Interfaces.Authentication;
using PropertyAPI.Infrastructure.Authentication;

namespace PropertyAPI.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services){
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
} 