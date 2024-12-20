using FluentValidation;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.CashRegisterDetails.DeleteCashRegisterDetailById;
public sealed record DeleteCashRegisterDetailByIdCommand(
    Guid Id) : IRequest<Result<string>>;
