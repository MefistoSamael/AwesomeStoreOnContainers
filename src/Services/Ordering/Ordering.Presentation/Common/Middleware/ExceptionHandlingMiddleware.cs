using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Common.Exceptions;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;

namespace Ordering.Presentation.Common.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (ValidationException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Validation error",
                Detail = "One or more validation errors has occurred",
            };

            if (exception.ValidationErrors is not null)
            {
                problemDetails.Extensions["errors"] = exception.ValidationErrors;
            }

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (DuplicateOrderItemException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Existing order item",
                Detail = exception.Message,
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (NonExistentOrderException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Non-existent order",
                Detail = exception.Message,
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (NonExistentProductException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Non-existent product",
                Detail = exception.Message,
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (InvalidOperationException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Invalid operation",
                Detail = exception.Message,
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (Exception exception)
        {
            throw;
#pragma warning disable CS0162 // Unreachable code detected
            await Console.Out.WriteLineAsync(exception.Message);
#pragma warning restore CS0162 // Unreachable code detected
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = "Error occured on server",
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
