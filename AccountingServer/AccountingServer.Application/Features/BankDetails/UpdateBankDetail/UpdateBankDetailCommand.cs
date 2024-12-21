using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.BankDetails.UpdateBankDetail;
public sealed record UpdateBankDetailCommand(
    Guid Id,
    Guid BankId,
    int Type,
    DateOnly Date,
    decimal Amount,
    string Description) : IRequest<Result<string>>;
