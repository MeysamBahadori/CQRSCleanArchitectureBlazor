using Mc2.CrudTest.Shared.Dto;
using Mc2.CrudTest.Shared.Dto.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers;

public class GetPagedCustomersQuery : IRequest<PagedResult<CustomerDto>>
{
    public GetPagedCustomersQuery(int maxResultCount, int skipCount, string? filter)
    {
        MaxResultCount = maxResultCount;
        SkipCount = skipCount;
        Filter = filter;
    }

    public int MaxResultCount { get; set; } 

    public int SkipCount { get; set; }

    public string? Filter { get; set; }

    public GetPagedCustomersQuery()
    {
        
    }

}