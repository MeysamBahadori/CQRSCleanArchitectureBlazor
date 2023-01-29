using Mc2.CrudTest.Client.Web.Components;

namespace Mc2.CrudTest.Client.Web.Service;

public partial class ExceptionHandler : IExceptionHandler
{
    public void Handle(Exception exception, IDictionary<string, object?>? parameters = null)
    {
        string? exceptionMessage = exception.Message ?? exception?.ToString();
        MessageBox.Show(exceptionMessage, "Error");
        Console.WriteLine(exceptionMessage);
    }
}
