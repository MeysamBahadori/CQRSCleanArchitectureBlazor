using Mc2.CrudTest.Domain.BusinessRule;
namespace Mc2.CrudTest.Domain.Entities.Customers;

public class CustomerValidPhoneNumberrRule : IBussinessRuleValidator
{
    private readonly ICustomerPhoneNumberValidator _customerPhoneNumberValidator;
    private readonly string? _countryCode;
    private readonly string? _phoneNumber;


    public CustomerValidPhoneNumberrRule(ICustomerPhoneNumberValidator customerPhoneNumberValidator, string? countryCode, string? phoneNumber)
    {
        _customerPhoneNumberValidator = customerPhoneNumberValidator;
        _countryCode = countryCode;
        _phoneNumber = phoneNumber;
    }

    public string InvalidMessage => "The phone number is not valid or not match with country code.";

    public bool IsValid()
    {
        return _customerPhoneNumberValidator.IsValid(_countryCode, _phoneNumber);
    }
}
