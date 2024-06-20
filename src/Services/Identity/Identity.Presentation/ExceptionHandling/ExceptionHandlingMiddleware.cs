﻿using Identity.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Presentation.Middleware;

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
        catch (DuplicateUserException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Existing user",
                Detail = exception.Message,
            };

            context.Response.StatusCode = StatusCodes.Status409Conflict;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (MissMatchingUserCredentialsException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Invalid user credentials",
                Detail = exception.Message,
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (NonExistentRoleException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Unexsiting role",
                Detail = exception.Message,
            };

            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (NonExistentUserException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                Title = "The specified user was not found",
                Detail = exception.Message,
            };

            context.Response.StatusCode = StatusCodes.Status404NotFound;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (UnauthorizedException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
                Title = "Invalid access token",
                Detail = exception.Message,
            };

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

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
