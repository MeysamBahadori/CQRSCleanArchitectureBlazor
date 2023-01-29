using System.Net;

namespace Mc2.CrudTest.Shared.Exceptions;

[Serializable]
public class ExceptionWrapperData
{
    public ExceptionWrapperData(HttpStatusCode statusCode, string error , string? errorType)
    {
        Error = error; 
        StatusCode = statusCode;
        ErrorType = errorType; 
    }

    public string Error { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public string? ErrorType { get; set; }

}
