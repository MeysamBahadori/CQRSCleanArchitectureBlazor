using AutoMapper;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Repository;
using Mc2.CrudTest.Shared.Dto.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(cancellationToken, request.Id);

        if(customer is null)
        {
            throw new EntityNotFoundException(nameof(Customer), request.Id);
        }

        return _mapper.Map<CustomerDto>(customer);

    }
}