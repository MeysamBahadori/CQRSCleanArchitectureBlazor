using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Entities.Customers;
using Mc2.CrudTest.Domain.Repository;
using MediatR;

namespace Mc2.CrudTest.Application.Customers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerEmailUniquenessChecker _customerEmailUniquenessChecker;
    private readonly ICustomerPhoneNumberValidator _customerPhoneNumberValidator;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerEmailUniquenessChecker customerUniquenessChecker, ICustomerPhoneNumberValidator customerPhoneNumberValidator)
    {
        _customerRepository = customerRepository;
        _customerEmailUniquenessChecker = customerUniquenessChecker;
        _customerPhoneNumberValidator = customerPhoneNumberValidator;
    }

    public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {

        var customer = await _customerRepository.GetByIdAsync(cancellationToken, request.Id);

        if (customer is null)
        {
            throw new EntityNotFoundException(nameof(customer), request.Id);
        }

        customer?.Update(
            request.Id,
            request.Firstname,
            request.Lastname,
            request.DateOfBirth,
            request.PhoneNumberCountryCode,
            request.PhoneNumber,
            request.Email,
            request.BankAccountNumber, _customerEmailUniquenessChecker, _customerPhoneNumberValidator
            );

        await _customerRepository.UpdateAsync(customer!, cancellationToken);

        return customer!.Id;
    }
}