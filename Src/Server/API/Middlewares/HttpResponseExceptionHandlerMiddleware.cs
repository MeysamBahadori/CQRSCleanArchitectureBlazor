using Ata.Teck.Shared.Exceptions;
using Mc2.CrudTest.Domain.BusinessRule;
using Mc2.CrudTest.Domain.CustomException;
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
            ExceptionWrapperData exData = new ExceptionWrapperData(ex.Message, HttpStatusCode.InternalServerError,AppConest.ErrorType_BusinessRuleValidation);

            await context.Response.WriteAsJsonAsync(exData);
        }
        catch (EntityNotFoundException ex)
        {
            ExceptionWrapperData exData = new ExceptionWrapperData(ex.Message, HttpStatusCode.InternalServerError, AppConest.ErrorType_Domain_Data);

            await context.Response.WriteAsJsonAsync(exData);

        }
        catch (Exception ex)
        {
            ExceptionWrapperData exData = new ExceptionWrapperData("Internal Server Error", HttpStatusCode.InternalServerError);

            await context.Response.WriteAsJsonAsync(exData);
        }

    }
    
}
