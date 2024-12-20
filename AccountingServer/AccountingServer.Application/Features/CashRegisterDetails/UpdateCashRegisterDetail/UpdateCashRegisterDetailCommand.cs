using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.CashRegisterDetails.UpdateCashRegisterDetail;
public sealed record UpdateCashRegisterDetailCommand(
    Guid Id,
    Guid CashRegisterId,
    int Type,
    DateOnly Date,
    decimal Amount,    
    string Description) : IRequest<Result<string>>;



