using Microsoft.Extensions.DependencyInjection;
using PropertyAPI.Application.Services.Authentication;

namespace PropertyAPI.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
} 