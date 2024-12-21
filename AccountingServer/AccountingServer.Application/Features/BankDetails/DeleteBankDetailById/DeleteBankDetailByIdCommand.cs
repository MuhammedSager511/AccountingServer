using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.BankDetails.DeleteBankDetailById;
public sealed record DeleteBankDetailByIdCommand(
    Guid Id) : IRequest<Result<string>>;
