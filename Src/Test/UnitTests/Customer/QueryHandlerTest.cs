using AutoMapper;
using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Application.Mappers;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.BusinessRule;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Infrastructure.Db;
using Mc2.CrudTest.Infrastructure.Domain.Customers;
using Mc2.CrudTest.Infrastructure.Seed;
using Mc2.CrudTest.Shared.Dto.Customer;
using Microsoft.EntityFrameworkCore;
using Moq;

using Xunit;
using Xunit.Sdk;

namespace Mc2.CrudTest.UnitTests;

public class QueryHandlerTest
{

    [Fact]
    public async Task Should_Return_CustomerId_Same_As_Input()
    {
        // Arrange

        //Get customer data from the infrastructure data seeder
        var mockCustomerSet = TestDataProvider.GetMockCustomerDbset();

        //Moc data context
        var mockContext = new Mock<CrudTestReadWriteContext>();
        mockContext.Setup(c => c.Set<Customer>()).Returns(mockCustomerSet.Object);

        var _customerRepository = new CustomerRepository(mockContext.Object);

        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CustomerMapperConfiguration());
        });
        var mapper = mockMapper.CreateMapper();

        Guid customerId = mockCustomerSet.Object.FirstOrDefault()!.Id;
        var mocRequest = new GetCustomerByIdQuery(customerId);

        // Act
        var commandHandler = new GetCustomerByIdQueryHandler(_customerRepository, mapper);
        var result = await commandHandler.Handle(mocRequest, CancellationToken.None);

        //Assert

        //The result must be same as input Id
        Assert.Equal(customerId, result.Id);
    }



    [Fact]
    public async Task Should_Return_Customer_Total_Same_As_The_DataSet_Count()
    {
        // Arrange

        //Get customer data from the infrastructure data seeder
        var mockCustomerSet = TestDataProvider.GetMockCustomerDbset();

        //Moc data context
        var mockContext = new Mock<CrudTestReadWriteContext>();
        mockContext.Setup(c => c.Set<Customer>()).Returns(mockCustomerSet.Object);

        var _customerRepository = new CustomerRepository(mockContext.Object);

        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CustomerMapperConfiguration());
        });
        var mapper = mockMapper.CreateMapper();

        int  total = mockCustomerSet.Object.Count();
        var mocRequest = new GetPagedCustomersQuery(10,0,"");

        // Act
        var commandHandler = new GetPagedCustomersQueryHandler(_customerRepository, mapper);
        var result = await commandHandler.Handle(mocRequest, CancellationToken.None);

        //Assert

        //The result count be same as the Dataset count
        Assert.Equal(total, result.TotalCount);
    }
}
