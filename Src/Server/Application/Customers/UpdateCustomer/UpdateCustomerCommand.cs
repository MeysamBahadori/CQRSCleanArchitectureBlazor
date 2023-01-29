using MediatR;

namespace Mc2.CrudTest.Application.Customers;

public class UpdateCustomerCommand : IRequest<Guid>
{
    public UpdateCustomerCommand(Guid? id,string? firstname, string? lastname, DateTimeOffset? dateOfBirth, string? phoneNumberCountryCode, string? phoneNumber, string? email, string? bankAccountNumber)
    {
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumberCountryCode=phoneNumberCountryCode;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    public Guid? Id { get; set; }

    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public DateTimeOffset? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhoneNumberCountryCode { get; set; }
    public string? Email { get; set; }
    public string? BankAccountNumber { get; set; }

    public UpdateCustomerCommand()
    {
        
    }
}