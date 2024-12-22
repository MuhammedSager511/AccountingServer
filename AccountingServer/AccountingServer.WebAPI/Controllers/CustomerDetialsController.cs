using AccountingServer.Application.Features.CustomerDetails.GetAllCustomerDetails;
using AccountingServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingServer.WebAPI.Controllers;

public sealed class CustomerDetailsController : ApiController
{
    public CustomerDetailsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCustomerDetailsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
