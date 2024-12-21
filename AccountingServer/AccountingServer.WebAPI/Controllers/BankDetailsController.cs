using AccountingServer.Application.Features.BankDetails.CreateBankDetail;
using AccountingServer.Application.Features.BankDetails.DeleteBankDetailById;
using AccountingServer.Application.Features.BankDetails.GetAllBankDetails;
using AccountingServer.Application.Features.BankDetails.UpdateBankDetail;
using AccountingServer.Application.Features.CashRegisterDetails.CreateCashRegisterDetail;
using AccountingServer.Application.Features.CashRegisterDetails.DeleteCashRegisterDetailById;
using AccountingServer.Application.Features.CashRegisterDetails.GetAllCashRegisterDetails;
using AccountingServer.Application.Features.CashRegisterDetails.UpdateCashRegisterDetail;
using AccountingServer.Application.Features.CashRegisters.CreateCashRegister;
using AccountingServer.Application.Features.CashRegisters.DeleteCashRegisterById;
using AccountingServer.Application.Features.CashRegisters.GetAllCashRegisters;
using AccountingServer.Application.Features.CashRegisters.UpdateCashRegister;
using AccountingServer.Application.Features.Users.CreateUser;
using AccountingServer.Application.Features.Users.DeleteUserById;
using AccountingServer.Application.Features.Users.GetAllUsers;
using AccountingServer.Application.Features.Users.UpdateUser;
using AccountingServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingServer.WebAPI.Controllers;

public sealed class BankDetailsController : ApiController
{
    public BankDetailsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllBankDetailsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBankDetailCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateBankDetailCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteBankDetailByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
