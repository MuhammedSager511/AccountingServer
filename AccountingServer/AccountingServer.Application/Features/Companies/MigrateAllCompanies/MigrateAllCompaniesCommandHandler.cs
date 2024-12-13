using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.Companies.MigrateAllCompanies;

internal sealed class MigrateAllCompaniesCommandHandler(
    ICompanyRepository companyRepository
    //ICompanyService companyService
    ) : IRequestHandler<MigrateAllCompaniesCommand, Result<string>>
{
    public async Task<Result<string>> Handle(MigrateAllCompaniesCommand request, CancellationToken cancellationToken)
    {
        List<Company> companies = await companyRepository.GetAll().ToListAsync(cancellationToken);

        //companyService.MigrateAll(companies);

        return "Company databases updated successfully";
    }
}
