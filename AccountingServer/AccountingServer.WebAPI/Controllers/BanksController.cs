using AccountingServer.Application.Features.Banks.CreateBank;
using AccountingServer.Application.Features.Banks.DeleteBankById;
using AccountingServer.Application.Features.Banks.GetAllBanks;
using AccountingServer.Application.Features.Banks.UpdateBank;
using AccountingServer.Application.Features.Users.CreateUser;
using AccountingServer.Application.Features.Users.DeleteUserById;
using AccountingServer.Application.Features.Users.GetAllUsers;
using AccountingServer.Application.Features.Users.UpdateUser;
using AccountingServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingServer.WebAPI.Controllers;

public sealed class BanksController : ApiController
{
    public BanksController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllBanksQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBankCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateBankCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteBankByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
