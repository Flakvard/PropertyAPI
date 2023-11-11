using Microsoft.Extensions.DependencyInjection;
using PropertyAPI.Application.Services.Authentication.Commands;
using PropertyAPI.Application.Services.Authentication.Queries;

namespace PropertyAPI.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        return services;
    }
} 