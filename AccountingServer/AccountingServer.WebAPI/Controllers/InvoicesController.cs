﻿using AccountingServer.Application.Features.Invoices.CreateInvoice;
using AccountingServer.Application.Features.Invoices.DeleteInvoiceById;
using AccountingServer.Application.Features.Invoices.GetAllInvoices;
using AccountingServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingServer.WebAPI.Controllers;

public sealed class InvoicesController : ApiController
{
    public InvoicesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }   

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteInvoiceByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
