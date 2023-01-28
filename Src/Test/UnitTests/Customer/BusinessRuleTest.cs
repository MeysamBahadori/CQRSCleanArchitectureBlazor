using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.BusinessRule;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Infrastructure.Db;
using Mc2.CrudTest.Infrastructure.Domain.Customers;
using Mc2.CrudTest.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Moq;

using Xunit;
using Xunit.Sdk;

namespace Mc2.CrudTest.UnitTests.CommandHandlers
{
    public class BusinessRuleTest
    {
        [Fact]
        public async Task Should_ThrowBusinessRuleException_When_EmailIsNotUniquee()
        {
            // Arrange

            //get customer data from the infrastructure data seeder
            var mockCustomerSet = GetMockCustomerDbset();

            var mockContext = new Mock<CrudTestReadWriteContext>();
            mockContext.Setup(c => c.Set<Customer>()).Returns(mockCustomerSet.Object);

            var _customerRepository = new CustomerRepository(mockContext.Object);
            var _customerUniquenessChecker = new CustomerUniquenessChecker(_customerRepository);

            var mocRequest = new Mock<CreateCustomerCommand>();

            //Seed customer email with a non-unique email address
            mocRequest.Object.Email = mockCustomerSet.Object.FirstOrDefault()?.Email;

            // Act
            var commandHandler = new CreateCustomerCommandHandler(_customerRepository, _customerUniquenessChecker);

            //Assert

            //The result must be a BusinessRuleValidationException exception with a specific message
            var exception =await Assert.ThrowsAsync<BusinessRuleValidationException>(() => commandHandler.Handle(mocRequest.Object, CancellationToken.None));

            Assert.Equal(DomainConest.ErrorMessage_CustomerUniqueEmailRule, exception.Message);
        }

        private Mock<DbSet<Customer>> GetMockCustomerDbset()
        {
            var customerData = DataSeeder.GetCustomersSeedData().AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customerData.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customerData.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customerData.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customerData.GetEnumerator);

            return mockSet;
        }
    }
}