using Mc2.CrudTest.Common;

namespace Mc2.CrudTest.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName, object Id) : 
        base(string.Format(AppConest.ErrorMessageFormat_EntityNotFoundException, entityName, Id))
    {

    }
}