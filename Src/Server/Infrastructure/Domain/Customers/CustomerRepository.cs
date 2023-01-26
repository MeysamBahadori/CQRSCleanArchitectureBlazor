using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Repository;
using Mc2.CrudTest.Infrastructure.Db;
using Mc2.CrudTest.Infrastructure.Repositories;

namespace Mc2.CrudTest.Infrastructure.Domain.Customers;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(CrudTestReadWriteContext dbContext) : base(dbContext)
    {
    }
   
}
