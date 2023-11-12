using Microsoft.AspNetCore.Mvc.Infrastructure;
using PropertyAPI.Api.Common.Errors;
using PropertyAPI.Api.Common.Mapping;

namespace PropertyAPI.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory,PropertyProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}