using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace planit.Application.Exceptions;
public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);

        }
        catch (System.Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    public static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        int statusCode = GetStatusCode(exception);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        if (exception.GetType() == typeof(ValidationException))
        {

            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                StatusCode = statusCode,
                Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage)
            }.ToString());

        }

        var response = new ExceptionModel
        {
            StatusCode = statusCode,
            Errors = new List<string>() { $"Error Message : {exception.Message}" }
        };

        return httpContext.Response.WriteAsync(response.ToString());
    }
    public static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}
