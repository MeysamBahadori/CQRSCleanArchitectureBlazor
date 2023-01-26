using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mc2.CrudTest.Infrastructure.Db;

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

        return services;
    }
}
