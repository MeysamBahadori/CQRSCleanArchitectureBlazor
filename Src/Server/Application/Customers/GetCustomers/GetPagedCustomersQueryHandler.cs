using AutoMapper;
using Mc2.CrudTest.Domain.Repository;
using Mc2.CrudTest.Shared.Dto;
using Mc2.CrudTest.Shared.Dto.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers;

public class GetPagedCustomersQueryHandler : IRequestHandler<GetPagedCustomersQuery, PagedResult<CustomerDto>>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public GetPagedCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<PagedResult<CustomerDto>> Handle(GetPagedCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = _customerRepository.TableNoTracking;

        if (!string.IsNullOrEmpty(request.Filter))
        {
            query = query.Where(c => c.Firstname!.Contains(request.Filter) || c.Lastname!.Contains(request.Filter));
        }

        int totalCount = query.Count();

        query = query.Skip(request.SkipCount).Take(request.MaxResultCount).OrderBy(c=>c.DateOfBirth);

        //for avoid "IQueryable doesn't implement IAsyncEnumerable exception" on unit test
        var data =await Task.FromResult(query.ToArray());

        return new PagedResult<CustomerDto>(_mapper.Map<List<CustomerDto>>(data), totalCount);
    }
}