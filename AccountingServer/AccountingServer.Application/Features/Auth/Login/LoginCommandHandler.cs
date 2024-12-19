using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.Auth.Login
{
    internal sealed class LoginCommandHandler(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IJwtProvider jwtProvider,
        ICompanyUserRepository companyUserRepository) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
    {
        public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? user = await userManager.Users
                .FirstOrDefaultAsync(p =>
                p.UserName == request.EmailOrUserName ||
                p.Email == request.EmailOrUserName,
                cancellationToken);

            if (user is null)
            {
                return (500, "User not found");
            }

            SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (signInResult.IsLockedOut)
            {
                TimeSpan? timeSpan = user.LockoutEnd - DateTime.UtcNow;
                if (timeSpan is not null)
                    return (500, $"User for entering your password incorrectly 3 times {Math.Ceiling(timeSpan.Value.TotalMinutes)} dakika süreyle bloke edilmiştir");
                else
                    return (500, "Your user has been blocked for 5 minutes for entering the wrong password 3 times");
            }

            if (signInResult.IsNotAllowed)
            {
                return (500, "Your e-mail address is not confirmed");
            }

            if (!signInResult.Succeeded)
            {
                return (500, "Your password is incorrect");
            }



            List<CompanyUser> companieUsers =
                await companyUserRepository
                .Where(p => p.AppUserId == user.Id)
                .Include(p => p.Company)
                .ToListAsync(cancellationToken);


            List<Company> companies = new();

            Guid? companyId = null;

            if (companieUsers.Count > 0)
            {
                companyId = companieUsers.First().CompanyId;

                companies = companieUsers.Select(s => new Company
                {
                    Id = s.CompanyId,
                    Name = s.Company!.Name,
                    TaxDepartment = s.Company!.TaxDepartment,
                    TaxNumber = s.Company!.TaxNumber,
                    FullAddress = s.Company!.FullAddress
                }).ToList();
            }


            var loginResponse = await jwtProvider.CreateToken(user, companyId, companies);

            return loginResponse;
        }
    }
}
