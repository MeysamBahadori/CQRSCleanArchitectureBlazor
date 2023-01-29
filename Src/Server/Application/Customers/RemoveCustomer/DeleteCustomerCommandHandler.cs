using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Entities.Customers;
using Mc2.CrudTest.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Customers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _customerRepository.DeleteAsync(new Customer() { Id = request.Id }, cancellationToken);
            return Unit.Value;
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new EntityNotFoundException(nameof(Customer), request.Id);
        }
        catch
        {
            throw;
        }
    }

}