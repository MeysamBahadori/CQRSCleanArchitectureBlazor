using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text.Json;

namespace Mc2.CrudTest.Infrastructure.Seed;
public static class DataSeeder
{
    static IEnumerable<TEntity> GetSeedData<TEntity>(string fileName)
         where TEntity : IEntity<Guid>
    {
        IEnumerable<TEntity> data = JsonSerializer.Deserialize<IEnumerable<TEntity>>(typeof(DataSeeder).Assembly.GetManifestResourceStream($"Mc2.CrudTest.Infrastructure.Seed.{fileName}")).OrderBy(c => (SqlGuid)c.Id);

        return data;
    }

    //For unit test propos
    public static IEnumerable<Customer> GetCustomersSeedData()
    {
        return  GetSeedData<Customer>("customers.json");
    }

    public static ModelBuilder SeedCustomers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasData(GetCustomersSeedData());
        return modelBuilder;
    }

}
