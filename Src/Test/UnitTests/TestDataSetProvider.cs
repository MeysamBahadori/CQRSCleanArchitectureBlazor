using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Mc2.CrudTest.UnitTests;

public  class TestDataSetProvider
{
    private static TestDataSetProvider? instance ;
    public List<Customer> CustomerDataSet { get; set; } = new();

    private TestDataSetProvider()
    {
        CustomerDataSet= DataSeeder.GetCustomersSeedData().ToList();
    }

    public static TestDataSetProvider Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TestDataSetProvider();
            }
            return instance;
        }
    }

    public Mock<DbSet<Customer>> GetMockCustomerDbset()
    {
        var mockSet = new Mock<DbSet<Customer>>();
        mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(CustomerDataSet.AsQueryable().Provider);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(CustomerDataSet.AsQueryable().Expression);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(CustomerDataSet.AsQueryable().ElementType);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(CustomerDataSet.GetEnumerator);

        mockSet
           .Setup(r => r.FindAsync(It.IsAny<object[]>(), CancellationToken.None))
           .ReturnsAsync((object?[]? Ids, CancellationToken token) => CustomerDataSet.FirstOrDefault(z => z.Id == (Guid)Ids[0]));

        mockSet
            .Setup(m => m.Remove(It.IsAny<Customer>()))
            .Callback<Customer>((entity) => CustomerDataSet.Remove(CustomerDataSet.First(c=>c.Id==entity.Id)));

        return mockSet;
    }

}
