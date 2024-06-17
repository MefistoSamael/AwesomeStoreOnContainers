using Microsoft.EntityFrameworkCore;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Presentation;
using Ordering.Presentation.Common.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly

    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
    context!.Database.Migrate();

    context!.Database.EnsureCreated();

#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
