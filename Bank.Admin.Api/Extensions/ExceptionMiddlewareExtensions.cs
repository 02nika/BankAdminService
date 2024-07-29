using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Bank.Admin.Api.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        UnauthorizedException => StatusCodes.Status401Unauthorized,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    var error = new ErrorDetail
                        { StatusCode = context.Response.StatusCode, Message = contextFeature.Error.Message };

                    if (context.Response.StatusCode == StatusCodes.Status500InternalServerError)
                    {
                        logger.LogError(contextFeature.Error, "Something went wrong: {error}", contextFeature.Error);
                        error.Message = "INTERNAL_ERROR";
                    }
                    else
                        logger.LogWarning("{customError}", error.ToString());

                    if (context.Response.StatusCode == StatusCodes.Status412PreconditionFailed)
                        error.Message = "TRANSACTION_REJECTED";

                    await context.Response.WriteAsync(error.ToString());
                }
            });
        });
    }
}