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

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="request">Contain customer data</param>
        /// <param name="cancellationToken">The Cancellation token</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(
                new CreateCustomerCommand(
                    request.Firstname,
                    request.Lastname,
                    request.DateOfBirth,
                    request.PhoneNumberCountryCode,
                    request.PhoneNumber,
                    request.Email,
                    request.BankAccountNumber
                )
                , cancellationToken);

            return Ok(id);
        }


    }
}
