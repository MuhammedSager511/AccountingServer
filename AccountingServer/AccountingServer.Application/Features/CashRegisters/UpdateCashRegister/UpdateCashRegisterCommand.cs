using AccountingServer.Domain.Enums;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.CashRegisters.UpdateCashRegister;
public sealed record UpdateCashRegisterCommand(
    Guid Id,
    string Name,
    int CurrencyTypeValue) : IRequest<Result<string>>;
