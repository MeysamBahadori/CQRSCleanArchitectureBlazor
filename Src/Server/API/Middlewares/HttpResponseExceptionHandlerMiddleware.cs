using Ata.Teck.Shared.Exceptions;
using Mc2.CrudTest.Common;
using Mc2.CrudTest.Common.Exceptions;
using Mc2.CrudTest.Domain.Exceptions;
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

            await context.Response.WriteAsJsonAsync(exData);
        }
        catch (EntityNotFoundException ex)
        {
            ExceptionWrapperData exData = new ExceptionWrapperData(HttpStatusCode.InternalServerError, ex.Message, AppConest.ErrorType_Domain_Data);

            await context.Response.WriteAsJsonAsync(exData);

        }
        catch
        {
            ExceptionWrapperData exData = new ExceptionWrapperData(HttpStatusCode.InternalServerError);

            await context.Response.WriteAsJsonAsync(exData);
        }

    }
    
}
