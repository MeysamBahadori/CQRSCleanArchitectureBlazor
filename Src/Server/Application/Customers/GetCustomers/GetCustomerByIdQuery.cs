using Mc2.CrudTest.Shared.Dto.Customers;
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