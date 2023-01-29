using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Shared.Dto.Customers;


public class CustomerDto
{
    public Guid? Id { get; set; }

    [Required]
    [StringLength(64)]
    public string? Firstname { get; set; }

    [Required]
    [StringLength(64)]
    public string? Lastname { get; set; }

    [Required]
    public DateTimeOffset? DateOfBirth { get; set; }

    [Required]
    [StringLength(3)]
    public string? PhoneNumberCountryCode { get; set; }

    [Required]
    [StringLength(32)]
    public string? PhoneNumber { get; set; }

    [Required]
    [StringLength(320)]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [StringLength(maximumLength : 34, MinimumLength = 12)]
    [RegularExpression("^[0-9]*$",ErrorMessage ="Only digits can be accepts")]
    public string? BankAccountNumber { get; set; }

}