using Mc2.CrudTest.Domain.Entities.Customers;
using Mc2.CrudTest.Domain.Repository;

namespace Mc2.CrudTest.Application.Customers
{
    public class CustomerUniquenessChecker : ICustomerEmailUniquenessChecker
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerUniquenessChecker(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool IsUnique(Guid? id, string? email)
        {
            if (id is null)
                return !_customerRepository.TableNoTracking.Any(c => c.Email == email);
            else
                return !_customerRepository.TableNoTracking.Any(c => c.Id != id && c.Email == email);
        }

    }
}