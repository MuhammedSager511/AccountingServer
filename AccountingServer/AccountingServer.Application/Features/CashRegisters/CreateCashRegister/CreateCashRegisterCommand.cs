using AccountingServer.Domain.Enums;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.CashRegisters.CreateCashRegister;
public sealed record CreateCashRegisterCommand(
    string Name,
    int CurrencyTypeValue) : IRequest<Result<string>>;
