using Microsoft.AspNetCore.Mvc.Infrastructure;
using PropertyAPI.Api.Common.Errors;
using PropertyAPI.Application;
using PropertyAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory,PropertyProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error"); // <-- Reexecutes the request to the error path

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
