using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.Companies.GetAllCompanies;

internal sealed class GetAllCompaniesQueryHandler: IRequestHandler<GetAllCompaniesQuery, Result<List<Company>>>
{
    private readonly ICompanyRepository companyRepository;
    private readonly ICacheService cacheService;



    public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository, ICacheService cacheService)
    {
        this.companyRepository = companyRepository;
        this.cacheService = cacheService;
    }
    public async Task<Result<List<Company>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        List<Company>? companies;

        companies = cacheService.Get<List<Company>>("companies");

        if (companies is null)
        {
            companies =
            await companyRepository
            .GetAll()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

            cacheService.Set<List<Company>>("companies", companies);
        }

        return companies;
    }
}
