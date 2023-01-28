using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Shared.Dto;
using Mc2.CrudTest.Shared.Dto.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        ///Get filtered customers pageable
        /// </summary>
        /// <param name="MaxResultCount">Maximum result count in each page</param>
        /// <param name="Skip">The number of skip page </param>
        /// <param name="filter">Filter value apply on name and family</param>
        /// <param name="cancellationToken">The Cancellation token</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<CustomerDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomers([Range(1,1000)]int MaxResultCount,[Range(0,int.MaxValue)] int Skip, string? filter, CancellationToken cancellationToken)
        {
            var customer = await _mediator.Send(new GetPagedCustomersQuery(MaxResultCount, Skip, filter), cancellationToken);
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
