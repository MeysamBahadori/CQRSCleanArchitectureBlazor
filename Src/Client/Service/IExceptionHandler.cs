namespace Mc2.CrudTest.Client.Web.Service;

public interface IExceptionHandler
{
    void Handle(Exception exception, IDictionary<string, object?>? parameters = null);
}
