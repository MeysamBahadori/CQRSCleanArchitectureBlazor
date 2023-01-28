using Mc2.CrudTest.Domain.Entities.Customers;
using PhoneNumbers;

namespace Mc2.CrudTest.Application.Customers;

public class CustomerPhoneNumberValidator : ICustomerPhoneNumberValidator
{
    public bool IsValid(string? countryCode, string? phoneNumber)
    {
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();

        try
        {
            PhoneNumber number = phoneNumberUtil.Parse(phoneNumber, countryCode);
            return phoneNumberUtil.IsValidNumber(number) && phoneNumberUtil.IsPossibleNumber(number);
        }
        catch
        {
            return false;

        }

    }
}
