using ErMenu.Api.Common.Response;
using ErMenu.Api.Resources;
using ErMenu.Domain.Common.Exceptions.Base;
using FluentValidation;
using Microsoft.Extensions.Localization; 

namespace ErMenu.Api.Middleware.Exceptions;

public class ExceptionMiddleware(
RequestDelegate next,
ILogger<ExceptionMiddleware> logger,
IStringLocalizer<SharedResource> _localizer)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            await HandleExceptionAsync(context, exception, _localizer);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception,
        IStringLocalizer<SharedResource> localizer)
    {
        var statusCode = exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,

            UnauthorizedException => StatusCodes.Status401Unauthorized,

            ForbiddenException => StatusCodes.Status403Forbidden,

            NotFoundException => StatusCodes.Status404NotFound,

            ConflictException => StatusCodes.Status409Conflict,

            ValidationException => StatusCodes.Status400BadRequest,

            _ => StatusCodes.Status500InternalServerError
        };

        var errorCode = GetExceptionErrorCode(exception);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var message = GetExceptionMessage(exception, localizer);


           

        var response = new ErrorResponse
        {
            StatusCode = statusCode,
            ErrorCode = errorCode,
            Message = message,
            IsSuccess = false
        };

        await context.Response.WriteAsJsonAsync(response);
    }




    private static string GetExceptionMessage(Exception exception, IStringLocalizer<SharedResource> localizer)
    {
        return (exception) switch
        {
            DomainException domainEx => localizer[domainEx.ErrorCode].ResourceNotFound
                ? domainEx.Message
                : localizer[domainEx.ErrorCode].Value,

            ValidationException validationEx =>
                string.Join(" | ",
                    validationEx.Errors.Select(e => e.ErrorMessage)),
                     

            _ => exception.Message + exception.ToString() + "An unexpected error occurred"
        };
    }

    private static string GetExceptionErrorCode(Exception exception)
    {
        return (exception) switch
        {
            DomainException domainEx => domainEx.ErrorCode,

            ValidationException validationEx =>
                string.Join(" | ",
                    validationEx.Errors.Select(e => e.ErrorCode)), 


            _ => "UnexpectedError"
        };
    }
}