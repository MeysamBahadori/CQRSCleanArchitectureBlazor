using Mc2.CrudTest.Shared.Dto.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Customers;

public class GetCustomerByIdQuery : IRequest<CustomerDto>
{
    public GetCustomerByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }

}