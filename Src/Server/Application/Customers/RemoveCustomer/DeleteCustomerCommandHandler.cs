using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.CustomException;
using Mc2.CrudTest.Domain.Entities.Customers;
using Mc2.CrudTest.Domain.Repository;
using MediatR;

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
        await _customerRepository.DeleteAsync(new Customer() {Id=request.Id },cancellationToken);

        return Unit.Value;
    }
   
}