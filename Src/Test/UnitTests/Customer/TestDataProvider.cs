using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.UnitTests;

public static class TestDataProvider
{
    public static Mock<DbSet<Customer>> GetMockCustomerDbset()
    {
        var customerData = DataSeeder.GetCustomersSeedData().AsQueryable();

        var mockSet = new Mock<DbSet<Customer>>();
        mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customerData.Provider);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customerData.Expression);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customerData.ElementType);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customerData.GetEnumerator);

        mockSet
           .Setup(r => r.FindAsync(It.IsAny<object[]>(), CancellationToken.None))
           .ReturnsAsync((object?[]? Ids,CancellationToken token) => customerData.FirstOrDefault(z => z.Id == (Guid)Ids[0]));

        return mockSet;
    }
}
