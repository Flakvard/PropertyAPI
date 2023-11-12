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
    app.UseAuthentication();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
