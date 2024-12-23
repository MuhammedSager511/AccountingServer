using AccountingServer.Application.Features.CustomerDetails.GetAllCustomerDetails;
using AccountingServer.Application.Features.ProductDetails.GetAllProductDetails;
using AccountingServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingServer.WebAPI.Controllers;

public sealed class ProductDetailsController : ApiController
{
    public ProductDetailsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
