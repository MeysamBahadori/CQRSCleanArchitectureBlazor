using Mc2.CrudTest.Common;
using Mc2.CrudTest.Common.Exceptions;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace Mc2.CrudTest.API.Middlewares;

public class HttpResponseExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public HttpResponseExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IHostEnvironment webHostEnvironment)
    {
        try
        {
            await _next(context);
        }
        catch(BusinessRuleValidationException  ex)
        {
            ExceptionWrapperData exData = new ExceptionWrapperData(HttpStatusCode.InternalServerError, ex.Message, AppConest.ErrorType_BusinessRuleValidation);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(exData);
        }
        catch (EntityNotFoundException ex)
        {
            ExceptionWrapperData exData = new ExceptionWrapperData(HttpStatusCode.InternalServerError, ex.Message, AppConest.ErrorType_Domain_Data);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(exData);

        }
        catch
        {
            ExceptionWrapperData exData = new ExceptionWrapperData(HttpStatusCode.InternalServerError,AppConest.ErrorMessage_Internal_Server_Error_Message, AppConest.ErrorType_Internal_Server);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(exData);
        }

    }
    
}
