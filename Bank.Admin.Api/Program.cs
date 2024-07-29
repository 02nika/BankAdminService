using Bank.Admin.Api.Extensions;
using Entities.Models.Enums;
using Microsoft.AspNetCore.HttpOverrides;
using Service.Contracts;
using Service.Mapper;
using Shared.Config;
using Shared.DTOs.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConfigSettings>(builder.Configuration.GetSection("ApplicationSettings"));

builder.Services.ConfigureCors();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
});
builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseAuthentication();
app.UseAuthorization();

#region user

var user = app.MapGroup("api/user").WithTags("User");

user.MapPost("register", async (IServiceManager serviceManager, RegisterUserDto userDto) =>
{
    await serviceManager.UserService.RegisterUserAsync(userDto);

    Results.Ok();
});

user.MapPost("login", async (IServiceManager serviceManager, LoginUserDto userDto) =>
{
    var res = await serviceManager.UserService.GetUserAsync(userDto);

    var token = serviceManager.AuthService.GenerateJwtToken((RoleType)res.Role);

    return Results.Ok(token);
});

#endregion

#region client

var client = app.MapGroup("api/client").WithTags("Client");

client.MapGet("", async (IServiceManager serviceManager) => { Results.Ok(); })
    .RequireAuthorization(policy => policy.RequireRole(RoleType.Admin.ToString()));

#endregion

app.Run();