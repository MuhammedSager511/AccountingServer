using AccountingServer.Application.Features.Auth.Login;
using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TS.Result;

namespace AccountingServer.Application.Features.Auth.ChangeCompany;

internal sealed class ChangeCompanyCommandHandler(
    ICompanyUserRepository companyUserRepository,
    UserManager<AppUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    IJwtProvider jwtProvider,
     ICacheService cacheService
    ) : IRequestHandler<ChangeCompanyCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(ChangeCompanyCommand request, CancellationToken cancellationToken)
    {
        if(httpContextAccessor.HttpContext is null)
        {
            return Result<LoginCommandResponse>.Failure("You are not authorized to perform this operation");
        }

        string? userIdString = httpContextAccessor.HttpContext.User.FindFirstValue("Id");

        if (string.IsNullOrEmpty(userIdString))
        {
            return Result<LoginCommandResponse>.Failure("You are not authorized to perform this operation");
        }

        AppUser? appUser = await userManager.FindByIdAsync(userIdString);
        if(appUser is null)
        {
            return Result<LoginCommandResponse>.Failure("User not found");
        }

        List<CompanyUser> companyUsers = await companyUserRepository
            .Where(p => p.AppUserId == appUser.Id).
            Include(p => p.Company).
            ToListAsync(cancellationToken);

        List<Company> companies = companyUsers.Select(s => new Company
        {
            Id = s.CompanyId,
            Name = s.Company!.Name,
            TaxDepartment = s.Company!.TaxDepartment,
            TaxNumber = s.Company!.TaxNumber,
            FullAddress = s.Company!.FullAddress,
        }).ToList();

        var response = await jwtProvider.CreateToken(appUser, request.CompanyId, companies);

        cacheService.RemoveAll();

        return response;
    }
}
