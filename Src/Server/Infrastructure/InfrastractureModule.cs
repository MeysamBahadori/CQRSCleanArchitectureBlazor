using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mc2.CrudTest.Infrastructure.Db;
using Mc2.CrudTest.Domain.Repository;
using Mc2.CrudTest.Infrastructure.Domain.Customers;
using Mc2.CrudTest.Domain.Entities.Customers;
using Mc2.CrudTest.Application.Customers;

namespace Mc2.CrudTest.Infrastructure;

public static class InfrastractureModule
{
    public static IServiceCollection AddInfrastractureDI(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("Default")?? throw new Exception("Connection string not found...");

        services.AddDbContext<CrudTestReadWriteContext>(options =>
        {
            options
            .UseSqlServer(configuration.GetConnectionString("Default"), sqlOpt =>
            {
                sqlOpt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
        });


        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<ICustomerEmailUniquenessChecker, CustomerUniquenessChecker>();
        services.AddTransient<ICustomerPhoneNumberValidator, CustomerPhoneNumberValidator>();

        return services;
    }
}
