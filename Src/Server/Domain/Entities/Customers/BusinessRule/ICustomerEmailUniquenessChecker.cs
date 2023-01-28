namespace Mc2.CrudTest.Domain.Entities.Customers;

public interface ICustomerEmailUniquenessChecker
{
    bool IsUnique(Guid? id, string? customerEmail);
}