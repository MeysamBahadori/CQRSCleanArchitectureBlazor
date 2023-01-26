using AutoMapper;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Shared.Dto.Customer;

namespace Mc2.CrudTest.Application.Mappers;
public class CustomerMapperConfiguration : Profile
{
    public CustomerMapperConfiguration()
    {
        CreateMap<Customer, CustomerDto>();
    }
}
