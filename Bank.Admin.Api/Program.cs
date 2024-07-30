using System.Security.Claims;
using Bank.Admin.Api.Extensions;
using Entities.Models.Enums;
using Microsoft.AspNetCore.HttpOverrides;
using Service.Contracts;
using Service.Mapper;
using Shared.Config;
using Shared.DTOs.Client;
using Shared.DTOs.Enums;
using Shared.DTOs.User;

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

var user = app.MapGroup("api/users").WithTags("Users");

user.MapPost("register", async (IServiceManager serviceManager, RegisterUserDto userDto) =>
{
    await serviceManager.UserService.RegisterUserAsync(userDto);

    Results.Ok();
});

user.MapPost("login", async (IServiceManager serviceManager, LoginUserDto userDto) =>
{
    var res = await serviceManager.UserService.GetUserAsync(userDto);

    var token = serviceManager.AuthService.GenerateJwtToken((RoleType)res.Role, res.Id);

    return Results.Ok(token);
});

#endregion

#region client

var client = app.MapGroup("api/clients").WithTags("Clients");

client.MapPost("", async (IServiceManager serviceManager, CreateClientDto clientDto) =>
    {
        await serviceManager.ClientService.CreateAsync(clientDto);

        return Results.Ok();
    })
    .RequireAuthorization(policy => policy.RequireRole(RoleType.Admin.ToString()));

client.MapGet("", async (IServiceManager serviceManager, HttpContext httpContext, int pageIndex, int pageSize,
        string? email = null, string? firstName = null, string? lastName = null,
        string? personalNumber = null, string? phoneNumber = null, GenderTypeDto? gender = null,
        bool orderBy = false
    ) =>
    {
        var clientParams = new FetchClientParams
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            PersonalNumber = personalNumber,
            PhoneNumber = phoneNumber,
            Gender = gender,
            PageIndex = pageIndex,
            PageSize = pageSize,
            OrderBy = orderBy
        };

        var userIdClaim = httpContext.User.FindFirst(ClaimTypes.UserData);
        var userId = Guid.Parse(userIdClaim!.Value);

        await serviceManager.ClientSuggestionService.CreateAsync(clientParams, userId);

        var response = await serviceManager.ClientService.GetAsync(clientParams);

        return Results.Ok(response);
    })
    .RequireAuthorization(policy => policy.RequireRole(RoleType.Admin.ToString()));

client.MapDelete("{id:guid}", async (IServiceManager serviceManager, Guid id) =>
    {
        await serviceManager.ClientService.DeleteAsync(id);

        return Results.Ok();
    })
    .RequireAuthorization(policy => policy.RequireRole(RoleType.Admin.ToString()));

#endregion

#region client search suggestions

var clientSuggestions = app.MapGroup("api/suggestions").WithTags("Suggestions");

clientSuggestions.MapGet("", async (IServiceManager serviceManager, HttpContext httpContext) =>
    {
        var userIdClaim = httpContext.User.FindFirst(ClaimTypes.UserData);
        var userId = Guid.Parse(userIdClaim!.Value);

        return Results.Ok(await serviceManager.ClientSuggestionService.GetAsync(userId));
    })
    .RequireAuthorization(policy => policy.RequireRole(RoleType.Admin.ToString()));

#endregion

app.Run();