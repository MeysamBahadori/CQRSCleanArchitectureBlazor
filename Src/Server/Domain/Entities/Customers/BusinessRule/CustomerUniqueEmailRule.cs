using Mc2.CrudTest.Common;
using Mc2.CrudTest.Common.Behaviours;

namespace Mc2.CrudTest.Domain.Entities.Customers;

public class CustomerUniqueEmailRule : IBussinessRuleValidator
{
    private readonly ICustomerEmailUniquenessChecker _customerEmailUniquenessChecker;

    private readonly Guid? _id;
    private readonly string? _email;

    public CustomerUniqueEmailRule(ICustomerEmailUniquenessChecker customerEmailUniquenessChecker, Guid? id, string? email )
    {
        _customerEmailUniquenessChecker = customerEmailUniquenessChecker;
        _email = email;
        _id = id;
    }
    public string InvalidMessage =>AppConest.ErrorMessage_CustomerUniqueEmailRule;

    public bool IsValid()
    {
       return _customerEmailUniquenessChecker.IsUnique(_id,_email);
    }
}
