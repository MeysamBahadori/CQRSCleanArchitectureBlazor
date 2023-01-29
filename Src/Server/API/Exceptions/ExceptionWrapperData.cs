using Mc2.CrudTest.API;
using System.Net;
using System.Runtime.Serialization;

namespace Ata.Teck.Shared.Exceptions;

[Serializable]
public class ExceptionWrapperData
{
    public ExceptionWrapperData(string? error, HttpStatusCode statusCode, string? errorType)
    {
        Error = error ?? AppConest.ErrorMessage_Internal_Server_Error_Message;
        StatusCode = statusCode;
        ErrorType = errorType ?? AppConest.ErrorType_Internal_Server;
    }


    public string Error { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public string? ErrorType { get; set; }

}
