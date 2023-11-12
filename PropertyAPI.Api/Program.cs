using PropertyAPI.Api;
using PropertyAPI.Application;
using PropertyAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error"); // <-- Reexecutes the request to the error path
    app.UseAuthentication(); // Authentication middleware fetches the correct handler/identiy-provider to handle authentication scheme (JwtBearer in InfrastructureLayer)
    app.UseAuthorization(); // Authorization middleware Can the user access the end point (checks the isAuthorizate in the Http bolean)
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
