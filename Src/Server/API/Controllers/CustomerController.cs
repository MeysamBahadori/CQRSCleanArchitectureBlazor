using Mc2.CrudTest.Application;
using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Shared.Dto.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mc2.CrudTest.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Get customer.
        /// </summary>
        /// <param name="Id">customer ID.</param>
        [Route("{Id}")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] Guid Id, CancellationToken cancellationToken)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(Id), cancellationToken);
            return Ok(customer);
        }

    }
}
