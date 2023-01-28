using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Entities.Customers;
using Mc2.CrudTest.Domain.Repository;
using MediatR;

namespace Mc2.CrudTest.Application.Customers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerEmailUniquenessChecker _customerEmailUniquenessChecker;
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerEmailUniquenessChecker customerUniquenessChecker)
    {
        _customerRepository = customerRepository;
        _customerEmailUniquenessChecker = customerUniquenessChecker;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            request.Firstname,
            request.Lastname,
            request.DateOfBirth,
            request.PhoneNumberCountryCode,
            request.PhoneNumber,
            request.Email,
            request.BankAccountNumber, _customerEmailUniquenessChecker
            );

        await _customerRepository.AddAsync(customer, cancellationToken);

        return customer.Id;
    }
}