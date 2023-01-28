using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Entities.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Domain.Customers;

[Table("Customers")]
public class Customer : BaseEntity
{
    [Column(TypeName = "VARCHAR")]
    [StringLength(64)]
    public string? Firstname { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(64)]
    public string? Lastname { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }

    [StringLength(3)]
    public string? PhoneNumberCountryCode { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(32)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(320)]
    public string? Email { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(34)]
    public string? BankAccountNumber { get; set; }

    public Customer(string? firstname, string? lastname, DateTimeOffset dateOfBirth, string? phoneNumberCountryCode, string? phoneNumber, string? email, string? bankAccountNumber)
    {
        Id =  Guid.NewGuid();
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        PhoneNumberCountryCode = phoneNumberCountryCode;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    public Customer()
    {

    }

    public static Customer Create(string? firstname, string? lastname, DateTimeOffset dateOfBirth, string? phoneNumberCountryCode, string? phoneNumber, string? email, string? bankAccountNumber, ICustomerEmailUniquenessChecker customerUniquenessChecker)
    {
        CheckRule(new CustomerUniqueEmailRule(customerUniquenessChecker, null, email));
        return new Customer(firstname, lastname, dateOfBirth, phoneNumberCountryCode, phoneNumber, email, bankAccountNumber);
    }
}
