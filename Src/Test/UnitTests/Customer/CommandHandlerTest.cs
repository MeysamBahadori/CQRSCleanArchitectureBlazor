using AutoMapper;
using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Application.Mappers;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Entities.Customers;
using Mc2.CrudTest.Infrastructure.Db;
using Mc2.CrudTest.Infrastructure.Domain.Customers;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Mc2.CrudTest.UnitTests;

public class CommandHandlerTest
{
    [Fact]
    public async Task Should_The_Output_CustomerId_Be_Equal_To_The_Input_CustomerId()
    {
        // Arrange

        //Get customer data from the infrastructure data seeder
        var mockCustomerSet = TestDataProvider.GetMockCustomerDbset();

        //Moc data context
        var mockContext = new Mock<CrudTestReadWriteContext>();
        mockContext.Setup(c => c.Set<Customer>()).Returns(mockCustomerSet.Object);

        var _customerRepository = new CustomerRepository(mockContext.Object);

        var _customerUniquenessChecker = new CustomerUniquenessChecker(_customerRepository);

        Customer customerToUpdate = mockCustomerSet.Object.FirstOrDefault()!;

        var _customerPhoneNumberValidator = new CustomerPhoneNumberValidator();

        var mocRequest = new UpdateCustomerCommand(
             customerToUpdate.Id,
             customerToUpdate.Firstname,
             customerToUpdate.Lastname,
             customerToUpdate.DateOfBirth,
             customerToUpdate.PhoneNumberCountryCode,
             customerToUpdate.PhoneNumber,
             customerToUpdate.Email,
             customerToUpdate.BankAccountNumber
            );

        // Act
        var commandHandler = new UpdateCustomerCommandHandler(_customerRepository, _customerUniquenessChecker,_customerPhoneNumberValidator);
        var updatedCustomerId = await commandHandler.Handle(mocRequest, CancellationToken.None);

        //Assert

        //The result must be same as input Id
        Assert.Equal(customerToUpdate.Id, updatedCustomerId);
    }

}
