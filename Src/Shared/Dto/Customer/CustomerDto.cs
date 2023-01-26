using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mc2.CrudTest.Shared.Dto.Customer;


public class CustomerDto
{
    public Guid Id { get; set; }

    [StringLength(64)]
    public string? Firstname { get; set; }

    [StringLength(64)]
    public string? Lastname { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }

    [StringLength(3)]
    public string? PhoneNumberCountryCode { get; set; }

    [StringLength(32)]
    public string? PhoneNumber { get; set; }

    [StringLength(320)]
    [EmailAddress]
    public string? Email { get; set; }

    [StringLength(maximumLength : 34, MinimumLength = 12)]
    [RegularExpression("^[0-9]*$",ErrorMessage ="Only digits can be accepts")]
    public string? BankAccountNumber { get; set; }

}