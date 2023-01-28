using Mc2.CrudTest.Shared.Dto;
using Mc2.CrudTest.Shared.Dto.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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