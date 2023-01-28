using Mc2.CrudTest.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Domain.Customers;

internal sealed class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        //I use data annotation for database entity configurations because it's more readable
        //And I put relations and indexes in this place...
        builder.HasIndex(p => new { p.Firstname, p.Lastname , p.DateOfBirth}).IsUnique();
    }
}
