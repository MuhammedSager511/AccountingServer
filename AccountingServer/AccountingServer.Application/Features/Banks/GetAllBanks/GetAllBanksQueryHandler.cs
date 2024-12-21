using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.Banks.GetAllBanks;

internal sealed class GetAllBanksQueryHandler(
    IBankRepository bankRepository,
    ICacheService cacheService) : IRequestHandler<GetAllBanksQuery, Result<List<Bank>>>
{
    public async Task<Result<List<Bank>>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
    {
        List<Bank>? banks;

        banks = cacheService.Get<List<Bank>>("banks");

        if(banks is null)
        {
            banks = await bankRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);

            cacheService.Set("banks", banks);
        }

        return banks;
    }
}
