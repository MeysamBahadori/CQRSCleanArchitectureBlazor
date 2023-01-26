using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

    public static ModelBuilder SeedCustomers(this ModelBuilder modelBuilder)
    {
        IEnumerable<Customer> customers = GetSeedData<Customer>("customers.json");

        modelBuilder.Entity<Customer>()
            .HasData(customers);

        return modelBuilder;
    }

}
