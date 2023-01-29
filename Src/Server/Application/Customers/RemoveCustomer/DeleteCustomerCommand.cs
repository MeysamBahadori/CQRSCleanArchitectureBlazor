using Mc2.CrudTest.Shared.Dto.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Application.Customers;

public class DeleteCustomerCommand : IRequest
{
    public DeleteCustomerCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}