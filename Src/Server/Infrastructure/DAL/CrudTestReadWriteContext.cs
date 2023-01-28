using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Db;

public class CrudTestReadWriteContext : DbContext
{
    public CrudTestReadWriteContext()
    {
        
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public CrudTestReadWriteContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrudTestReadWriteContext).Assembly);

        modelBuilder
          .SeedCustomers();
    }
}
