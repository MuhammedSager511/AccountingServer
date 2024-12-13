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
    //private readonly ICacheService cacheService;

    public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository )
    {
        this.companyRepository = companyRepository;
      
    }
    public async Task<Result<List<Company>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        //List<Company>? companies;

        //companies = cacheService.Get<List<Company>>("companies");
        
        List<Company> companies =
            await companyRepository
            .GetAll()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);


        //cacheService.Set<List<Company>>("companies", companies);


        return companies;
    }
}
