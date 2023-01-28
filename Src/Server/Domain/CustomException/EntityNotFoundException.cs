namespace Mc2.CrudTest.Domain.CustomException;

public class EntityNotFoundException : Exception
{
    const string Message = "{0} entity with Id <{1}> not found";
    public EntityNotFoundException(string entityName, object Id) : 
        base(string.Format(Message, entityName, Id))
    {

    }
}