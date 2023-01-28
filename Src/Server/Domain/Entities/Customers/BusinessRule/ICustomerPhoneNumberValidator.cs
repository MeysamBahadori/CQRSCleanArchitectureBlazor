namespace Mc2.CrudTest.Domain.Entities.Customers;

public interface ICustomerPhoneNumberValidator
{
    bool IsValid(string? CountryCode, string? phoneNumber);
}
