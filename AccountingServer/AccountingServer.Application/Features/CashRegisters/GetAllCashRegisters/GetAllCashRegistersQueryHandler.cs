﻿using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.CashRegisters.GetAllCashRegisters;

internal sealed class GetAllCashRegistersQueryHandler(
    ICashRegisterRepository cashRegisterRepository,
    ICacheService cacheService) : IRequestHandler<GetAllCashRegistersQuery, Result<List<CashRegister>>>
{
    public async Task<Result<List<CashRegister>>> Handle(GetAllCashRegistersQuery request, CancellationToken cancellationToken)
    {
        List<CashRegister>? cashRegisters;

        cashRegisters = cacheService.Get<List<CashRegister>>("cashRegisters");

        if(cashRegisters is null)
        {
            cashRegisters =
            await cashRegisterRepository
            .GetAll().OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

            cacheService.Set<List<CashRegister>>("cashRegisters", cashRegisters);
        }
        

        return cashRegisters;
    }
}
