using Microsoft.AspNetCore.Mvc.Infrastructure;
using PropertyAPI.Api.Errors;
using PropertyAPI.Api.Filters;
using PropertyAPI.Application;
using PropertyAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory,PropertyProblemDetailsFactory>();
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error"); // <-- Reexecutes the request to the error path
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
