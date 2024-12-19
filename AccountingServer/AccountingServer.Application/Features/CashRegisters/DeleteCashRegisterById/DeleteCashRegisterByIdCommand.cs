using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.CashRegisters.DeleteCashRegisterById;
public sealed record DeleteCashRegisterByIdCommand(
    Guid Id) : IRequest<Result<string>>;
