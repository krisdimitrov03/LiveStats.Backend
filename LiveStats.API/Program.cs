using LiveStats.API.Extensions;
using LiveStats.Core.Football.Managers;
using LiveStats.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Services.GetApplicationSettings(builder.Configuration);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddIdentity()
    .AddJwtAuthentication(appSettings)
    .AddUserDefinedServices()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDevelopmentSettings();

app.UseRouting()
    .ConfigureCors()
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization()
    .MapControllers()
    .SeedDatabase()
    .GenerateRandomMatches(20)
    ;

app.Run();
