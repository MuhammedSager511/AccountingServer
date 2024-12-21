using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.BankDetails.GetAllBankDetails;

internal sealed class GetAllBankDetailsQueryHandler(
    IBankRepository bankRepository) : IRequestHandler<GetAllBankDetailsQuery, Result<Bank>>
{
    public async Task<Result<Bank>> Handle(GetAllBankDetailsQuery request, CancellationToken cancellationToken)
    {
        Bank? bank =
            await bankRepository
            .Where(p => p.Id == request.BankId)
            .Include(p => p.Details!.Where(p => p.Date >= request.StartDate && p.Date <= request.EndDate))
            .FirstOrDefaultAsync(cancellationToken);

        if (bank is null)
        {
            return Result<Bank>.Failure("Bank not found");
        }

        return bank;
    }
}
